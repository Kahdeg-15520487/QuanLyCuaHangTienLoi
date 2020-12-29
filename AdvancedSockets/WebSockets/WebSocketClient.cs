using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using AdvancedSockets.Http;
using AdvancedSockets.Http.Client;

namespace AdvancedSockets.WebSockets
{
    public class WebSocketClient
    {
        private Socket socket;
        private Thread thread;

        public WebSocketStatus Status { get; private set; }
        public int ReceiveTimeout { get; private set; }
        public int SendTimeout { get; private set; }

        public WebSocketClient() : this(1000 * 60 * 30)
        {

        }
        public WebSocketClient(int receiveTimeout) : this(receiveTimeout, 1000 * 30)
        {

        }
        public WebSocketClient(int receiveTimeout, int sendTimeout)
        {
            Status = WebSocketStatus.Opening;
            ReceiveTimeout = receiveTimeout;
            SendTimeout = sendTimeout;
        }

        public void Connect(Uri uri)
        {
            var buffer = new byte[1024];

            if (!Regex.IsMatch(uri.ToString(), "ws://|wss://"))
            {
                OnError?.Invoke($"Wrong protocol scheme for url {uri}. Expected ws:// or wss://", null);
                return;
            }

            try
            {
                IPEndPoint ipEndpoint = ResolveIpAddress(uri);
                var key = WebSocketUtils.GenerateRequestKey();

                // Create the client socket
                socket = new Socket(ipEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.ReceiveTimeout = ReceiveTimeout;
                socket.SendTimeout = SendTimeout;
                socket.Connect(ipEndpoint);

                // Send the handshake http request
                var httpRequest = new HttpRequest(socket);
                httpRequest.Method = HttpMethod.Get;
                httpRequest.Path = uri.AbsolutePath;
                httpRequest.Headers.Host = uri.Host;
                httpRequest.Headers.Upgrade = "websocket";
                httpRequest.Headers.Connection = "keep-alive, upgrade";
                httpRequest.Headers.Origin = Dns.GetHostName();
                httpRequest.Headers.SecWebSocketKey = key;
                httpRequest.Headers.SecWebSocketProtocol = "chat, superchat";
                httpRequest.Headers.SecWebSocketVersion = "13";
                httpRequest.Send();

                // Wait for a response
                var received = socket.Receive(buffer);

                if (received > 0)
                {
                    var data = buffer.Slice(0, received);
                    var httpResponse = new HttpResponse(data);

                    if (httpResponse.StatusCode != HttpStatusCode.SwitchingProtocols)
                    {
                        if (httpResponse.StatusCode == HttpStatusCode.Moved)
                        {
                            throw new Exception($"Server endpoint moved to {httpResponse.Headers.Location}");
                        }
                        if (httpResponse.StatusCode == HttpStatusCode.Redirect)
                        {
                            throw new Exception($"Server endpoint redirects to {httpResponse.Headers.Location}");
                        }
                        if ((int)httpResponse.StatusCode > 400)
                        {
                            throw new Exception($"Server returned a {httpResponse.StatusCode}: {Encoding.ASCII.GetString(httpResponse.Body)}");
                        }

                        throw new Exception($"Server returned {(int)httpResponse.StatusCode} instead of 101");
                    }
                    if (httpResponse.Headers.SecWebSocketAccept == null)
                    {
                        throw new Exception("Header 'sec-websocket-accept' missing");
                    }
                    if (httpResponse.Headers.Connection == null)
                    {
                        throw new Exception("Header 'connection' missing");
                    }
                    if (httpResponse.Headers.Upgrade == null)
                    {
                        throw new Exception("Header 'upgrade' missing");
                    }
                    if (httpResponse.Headers.Connection.ToLower() != "upgrade")
                    {
                        throw new Exception($"Server provided '{httpResponse.Headers.Connection}' for header 'connection'. Expected 'upgrade'");
                    }
                    if (httpResponse.Headers.Upgrade.ToLower() != "websocket")
                    {
                        throw new Exception($"Server provided '{httpResponse.Headers.Upgrade}' for header 'upgrade'. Expected 'websocket'");
                    }
                    if (httpResponse.Headers.SecWebSocketAccept != WebSocketUtils.GenerateResponseKey(key))
                    {
                        throw new Exception("Server provided wrong accept key in header 'sec-websocket-accept'");
                    }

                    // Start the thread
                    thread = new Thread(Thread_Callback);
                    thread.Start();
                }
                else
                {
                    throw new Exception("No response received");
                }
            }
            catch (Exception ex)
            {
                Status = WebSocketStatus.Closed;
                OnError?.Invoke("An error occured during handshake", ex);
            }
        }

        private static IPEndPoint ResolveIpAddress(Uri uri)
        {
            IPHostEntry ipHostEntry = null;
            try
            {
                ipHostEntry = Dns.GetHostEntry(uri.Host);
            }
            catch (Exception)
            {
                IPAddress.TryParse(uri.Host, out IPAddress ip);
                return new IPEndPoint(ip, uri.Port);
            }
            var ipAddress = ipHostEntry.AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
            var ipEndpoint = new IPEndPoint(ipAddress, uri.Port);
            return ipEndpoint;
        }

        public void CloseConnection()
        {
            CloseConnection(WebSocketCloseStatus.NormalClosure, null);
        }
        internal void CloseConnection(WebSocketCloseStatus status, string reason)
        {
            try
            {
                var statusBinary = ((int)status).IntToBinaryString();
                var data = new List<byte>();
                data.Add(statusBinary.Substring(0, 8).BinaryStringToByte());
                data.Add(statusBinary.Substring(8, 8).BinaryStringToByte());

                if (!string.IsNullOrEmpty(reason))
                {
                    data.AddRange(Encoding.ASCII.GetBytes(reason));
                }

                var message = new WebSocketMessage(null, WebSocketOpcode.Closing, false);
                var result = message.Encode();

                socket.Send(result);
                Status = WebSocketStatus.Closing;
            }
            catch (Exception ex)
            {
                Status = WebSocketStatus.Closed;
                OnError?.Invoke("An error occured while closing the connection", ex);
            }
        }

        public void AbortConnection()
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                OnError?.Invoke("An error occured while aborting the connection", ex);
            }
            finally
            {
                Status = WebSocketStatus.Closed;
            }
        }

        public void Send(byte[] data)
        {
            try
            {
                var message = new WebSocketMessage(data, WebSocketOpcode.Text, true);
                var result = message.Encode();

                socket.Send(result);
            }
            catch (Exception ex)
            {
                Status = WebSocketStatus.Closed;
                OnError?.Invoke("An error occured while sending a message to the server", ex);
            }
        }

        /* THREADING */
        private void Thread_Callback()
        {
            byte[] buffer = new byte[WebSocketConstants.MAX_BUFFER_SIZE];
            byte[] data = new byte[0];

            try
            {
                OnConnect?.Invoke();
            }
            catch (Exception ex)
            {
                OnError?.Invoke("An error occured during the OnConnect event", ex);
            }

            try
            {
                Status = WebSocketStatus.Open;

                while (Status != WebSocketStatus.Closed)
                {
                    int bytesReceived = socket.Receive(buffer);

                    // If the client still has bytes, add them to our data buffer
                    // If no bytes were received it means the client closed the connection roughly
                    if (bytesReceived > 0)
                    {
                        data = data.Push(buffer.Slice(0, bytesReceived));
                    }
                    else
                    {
                        Status = WebSocketStatus.Closed;
                        break;
                    }

                    while (data.Length > 0)
                    {
                        var message = new WebSocketMessage(data);
                        data = message.Decode();

                        // Do not allow the buffer length to exceed the max buffer size
                        if ((uint)data.Length > WebSocketConstants.MAX_BUFFER_SIZE)
                        {
                            CloseConnection(WebSocketCloseStatus.BufferOverflow, $"Buffer length exceeds the maximum of {WebSocketConstants.MAX_BUFFER_SIZE} bytes");
                            break;
                        }

                        // Otherwise handle the received data per type
                        if (message.Opcode == WebSocketOpcode.Text)
                        {
                            OnMessage?.Invoke(message.Message);
                        }

                        if (message.Opcode == WebSocketOpcode.Closing)
                        {
                            if (Status == WebSocketStatus.Open)
                            {
                                CloseConnection();
                            }

                            Status = WebSocketStatus.Closed;
                            break;
                        }

                        if (message.Incomplete)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke("An error occured while receiving data from the server", ex);
                Status = WebSocketStatus.Closed;
            }

            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                OnError?.Invoke("An error occured while trying to shutdown the socket", ex);
            }

            try
            {
                OnDisconnect?.Invoke();
            }
            catch (Exception ex)
            {
                OnError?.Invoke("An error occured in the OnDisconnect event", ex);
            }
        }

        /* EVENTS */
        public delegate void OnConnectDelegate();
        public delegate void OnDisconnectDelegate();
        public delegate void OnMessageDelegate(byte[] message);
        public delegate void OnErrorDelegate(string error, Exception ex);

        public event OnConnectDelegate OnConnect;
        public event OnDisconnectDelegate OnDisconnect;
        public event OnMessageDelegate OnMessage;
        public event OnErrorDelegate OnError;
    }
}