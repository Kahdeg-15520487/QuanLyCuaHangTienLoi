using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using AdvancedSockets.Http;
using AdvancedSockets.Http.Server;

namespace AdvancedSockets.WebSockets
{
    public class WebSocketServer
    {
        private int receiveTimeout;
        private int sendTimeout;
        private int maxConnections;
        private int bufferSize;
        private Uri uri;
        private Thread threadUpdate;
        private Thread threadListen;

        public List<Client> Clients { get; private set; }
        public bool Running { get; private set; }

        public WebSocketServer(string url) : this(new Uri(url))
        {

        }
        public WebSocketServer(Uri uri)
        {
            Clients = new List<Client>();

            this.receiveTimeout = 1000 * 60 * 30;
            this.sendTimeout = 1000 * 30;
            this.maxConnections = 1000;
            this.bufferSize = 1024 * 1024 * 4; // 4MB
            this.uri = uri;
        }

        public void Start()
        {
            Running = true;

            // Start the update thread
            threadUpdate = new Thread(UpdateThreadCallback);
            threadUpdate.Start();

            // Start the listen threads
            threadListen = new Thread(ListenThreadCallback);
            threadListen.Start();
        }

        public void Stop()
        {
            Running = false;

            foreach (var client in Clients)
            {
                client.AbortConnection();
            }
        }

        public void Broadcast(string data)
        {
            Broadcast(Encoding.ASCII.GetBytes(data));
        }
        public void Broadcast(byte[] data)
        {
            foreach (Client client in Clients)
            {
                client.Send(data);
            }
        }
        /* THREAD CALLBACKS */
        private void ListenThreadCallback()
        {
            try
            {
                var hostEntry = Dns.GetHostEntry(uri.Host);
                var ip = hostEntry.AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
                var endPoint = new IPEndPoint(ip, uri.Port);

                var listener = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(endPoint);
                listener.Listen(maxConnections);

                while (Running)
                {
                    AcceptConnections(listener);
                }
            }
            catch (Exception ex)
            {
                Running = false;
                OnServerError?.Invoke(ex);
            }
        }
        private void AcceptConnections(Socket listener)
        {
            try
            {
                var handler = listener.Accept();
                handler.ReceiveTimeout = receiveTimeout;
                handler.SendTimeout = sendTimeout;

                var buffer = new byte[bufferSize];
                var bytesReceived = handler.Receive(buffer);

                if (bytesReceived > 0)
                {
                    HandleNewClient(handler, buffer.Slice(0, bytesReceived));
                }
            }
            catch (Exception ex)
            {
                OnServerError?.Invoke(ex);
            }
        }
        private void HandleNewClient(Socket handler, byte[] data)
        {
            try
            {
                // Parse the HTTP request
                var httpRequest = new HttpRequest(data, false);

                // Validate the http request
                if (httpRequest.Path != uri.AbsolutePath)
                {
                    throw new HttpException(HttpStatusCode.NotFound, $"WebSocket server is not listening on path {httpRequest.Path} but on {uri.AbsolutePath}");
                }
                if (string.IsNullOrEmpty(httpRequest.Headers.Connection))
                {
                    throw new HttpException(HttpStatusCode.BadRequest, "Header 'Connection' is missing or empty");
                }
                if (string.IsNullOrEmpty(httpRequest.Headers.Upgrade))
                {
                    throw new HttpException(HttpStatusCode.BadRequest, "Header 'Upgrade' is missing or empty");
                }
                if (string.IsNullOrEmpty(httpRequest.Headers.SecWebSocketKey))
                {
                    throw new HttpException(HttpStatusCode.BadRequest, "Header 'Sec-WebSocket-Key' is missing or empty");
                }
                if (!httpRequest.Headers.Connection.Split(',').Any(x => x.ToLower().Trim() == "upgrade"))
                {
                    throw new HttpException(HttpStatusCode.BadRequest, "Invalid connection header. Expected: upgrade");
                }
                if (httpRequest.Headers.Upgrade.ToLower() != "websocket")
                {
                    throw new HttpException(HttpStatusCode.BadRequest, "Invalid upgrade header. Expected: websocket");
                }

                // Generate the handshake http response and send it
                var httpResponse = new HttpResponse(handler);
                httpResponse.StatusCode = HttpStatusCode.SwitchingProtocols;
                httpResponse.Headers.Connection = "Upgrade";
                httpResponse.Headers.Upgrade = "websocket";
                httpResponse.Headers.SecWebSocketAccept = WebSocketUtils.GenerateResponseKey(httpRequest.Headers.SecWebSocketKey);
                httpResponse.Send(true);
            }
            catch(HttpException ex)
            {
                var httpResponse = new HttpResponse(handler);
                httpResponse.StatusCode = ex.Status;
                httpResponse.Body = Encoding.ASCII.GetBytes(ex.Message);
                httpResponse.Send();
                return;
            }
            catch (Exception ex)
            {
                var httpResponse = new HttpResponse(handler);
                httpResponse.StatusCode = HttpStatusCode.InternalServerError;
                httpResponse.Body = Encoding.ASCII.GetBytes("Something went wrong");
                httpResponse.Send();

                OnServerError?.Invoke(ex);
                return;
            }

            try
            {
                // Create the client
                var client = new Client();
                client.OnConnect += OnClientConnect;
                client.OnMessage += OnClientMessage;
                client.OnError += OnClientError;
                client.OnDisconnect += OnClientDisconnect;
                client.Connect(handler, data);

                // Add the client to our list of clients
                Clients.Add(client);
            }
            catch (Exception ex)
            {
                OnServerError?.Invoke(ex);
            }
        }

        private void UpdateThreadCallback()
        {
            // Update each 5 seconds
            while (Running)
            {
                try
                {
                    for (int i = 0; i < Clients.Count; i++)
                    {
                        var client = Clients[i];

                        // If the client is not connected anymore, remove it from the list
                        if (client.Status == WebSocketStatus.Closed)
                        {
                            Clients.Remove(client);
                            continue;
                        }
                    }
                }
                catch (Exception ex)
                {
                    OnServerError?.Invoke(ex);
                }

                Thread.Sleep(10 * 1000);
            }
        }

        /* EVENTS */
        public delegate void OnClientConnectDelegate(Client client);
        public event OnClientConnectDelegate OnClientConnect;
        public delegate void OnClientMessageDelegate(Client client, byte[] message);
        public event OnClientMessageDelegate OnClientMessage;
        public delegate void OnClientErrorDelegate(Client client, Exception exception);
        public event OnClientErrorDelegate OnClientError;
        public delegate void OnServerErrorDelegate(Exception exception);
        public event OnServerErrorDelegate OnServerError;
        public delegate void OnClientDisconnectDelegate(Client client);
        public event OnClientDisconnectDelegate OnClientDisconnect;
    }
}