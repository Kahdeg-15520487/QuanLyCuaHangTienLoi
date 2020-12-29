using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace AdvancedSockets.WebSockets
{
    public class Client
    {
        private Thread thread;
        private Socket socket;

        public string Id { get; private set; }
        public WebSocketStatus Status { get; private set; }
        public IPAddress IPAddress { get; private set; }
        public Dictionary<string, string> Properties { get; private set; }

        public Client()
        {
            Id = Guid.NewGuid().ToString();
            Properties = new Dictionary<string, string>();
            Status = WebSocketStatus.Opening;
        }

        public void Connect(Socket socket, byte[] data)
        {
            Connect(socket, Encoding.ASCII.GetString(data));
        }
        public void Connect(Socket socket, string httpRequest)
        {
            try
            {
                this.socket = socket;
                IPAddress = ((IPEndPoint)(socket.RemoteEndPoint)).Address;

                // Create the thread and start it
                thread = new Thread(ThreadCallback);
                thread.Start();
            }
            catch (Exception ex)
            {
                Status = WebSocketStatus.Closed;
                OnError?.Invoke(this, ex);
            }
        }

        public void Send(byte[] data)
        {
            if (Status != WebSocketStatus.Open)
            {
                throw new WebSocketException("Unable to send data. WebSocket is not open");
            }

            try
            {
                var message = new WebSocketMessage(data, WebSocketOpcode.Text, false);
                var result = message.Encode();

                socket.Send(result);
            }
            catch (Exception ex)
            {
                Status = WebSocketStatus.Closed;
                OnError?.Invoke(this, ex);
            }
        }

        public void CloseConnection()
        {
            CloseConnection(WebSocketCloseStatus.NormalClosure, null);
        }
        internal void CloseConnection(WebSocketCloseStatus status, string reason)
        {
            try
            {
                var statusBinary = ((int)status).IntToBinaryString().PadLeft(16, '0');
                var data = new List<byte>();
                data.Add(statusBinary.Substring(0, 8).BinaryStringToByte());
                data.Add(statusBinary.Substring(8, 8).BinaryStringToByte());

                if (!string.IsNullOrEmpty(reason))
                {
                    data.AddRange(Encoding.ASCII.GetBytes(reason));
                }

                var message = new WebSocketMessage(data.ToArray(), WebSocketOpcode.Closing, false);
                var result = message.Encode();

                socket.Send(result);
                Status = WebSocketStatus.Closing;
            }
            catch (Exception ex)
            {
                Status = WebSocketStatus.Closed;
                OnError?.Invoke(this, ex);
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
                OnError?.Invoke(this, ex);
            }
            finally
            {
                Status = WebSocketStatus.Closed;
            }
        }

        public long Ping()
        {
            var ping = new Ping();
            var reply = ping.Send(IPAddress);

            if (reply.Status == IPStatus.Success)
            {
                return reply.RoundtripTime;
            }

            return -1;
        }

        private void ThreadCallback()
        {
            var buffer = new byte[1024 * 1024 * 4];
            var data = new byte[0];

            try
            {
                OnConnect?.Invoke(this);
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, ex);
            }
            
            try
            {
                Status = WebSocketStatus.Open;

                // Go in a loop to wait for incoming messages
                while (Status != WebSocketStatus.Closed)
                {
                    int bytesReceived = socket.Receive(buffer);

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

                        // IETF RFC 6455 5.3
                        // Clients are required to mask their bytes, if they did not the server has to send a close frame with a 1002 status as body
                        if (!message.Masked)
                        {
                            CloseConnection(WebSocketCloseStatus.ProtocolError, "Invalid WebSocket frame: MASK must be set.");
                            break;
                        }

                        if (message.Opcode == WebSocketOpcode.Text)
                        {
                            OnMessage?.Invoke(this, message.Message);
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
                    }
                }
            }
            catch (Exception ex)
            {
                Status = WebSocketStatus.Closed;
                OnError?.Invoke(this, ex);
            }

            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, ex);
            }

            try
            {
                OnDisconnect?.Invoke(this);
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, ex);
            }
        }

        /* EVENTS */
        public event WebSocketServer.OnClientConnectDelegate OnConnect;
        public event WebSocketServer.OnClientMessageDelegate OnMessage;
        public event WebSocketServer.OnClientErrorDelegate OnError;
        public event WebSocketServer.OnClientDisconnectDelegate OnDisconnect;
    }
}