using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using AdvancedSockets.Sockets;

namespace AdvancedSockets.Http.Server
{
    public class HttpServer
    {
        private Thread thread;
        private IPEndPoint endPoint;

        public bool Running { get; private set; }

        public HttpServer(int port) : this(Dns.GetHostName(), 8080)
        {

        }
        public HttpServer(string host, int port)
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(host);
            IPAddress iPAddress = hostEntry.AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);

            this.endPoint = new IPEndPoint(iPAddress, port);
        }
        public HttpServer(IPEndPoint endPoint)
        {
            this.endPoint = endPoint;
        }

        public void Start()
        {
            Running = true;

            thread = new Thread(Thread_Callback);
            thread.Start();
        }

        private void Thread_Callback()
        {
            // Create a TCP/IP socket
            Socket listener = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Start listening to incoming requests
            listener.Bind(endPoint);
            listener.Listen(1000);

            // Create the accept object
            SocketAccept accept = new SocketAccept();
            accept.Socket = listener;
            accept.ResetEvent = new ManualResetEvent(false);

            while (true)
            {
                try
                {
                    accept.ResetEvent.Reset();
                    accept.Socket.BeginAccept(AcceptCallback, accept);
                    accept.ResetEvent.WaitOne();
                }
                catch (Exception ex)
                {
                    OnException?.Invoke(ex);
                }
            }
        }

        private void AcceptCallback(IAsyncResult result)
        {
            try
            {
                SocketAccept accept = (SocketAccept)result.AsyncState;

                // Continue the main thread
                accept.ResetEvent.Set();

                // Get the socket handler
                Socket listener = accept.Socket;
                Socket handler = listener.EndAccept(result);

                // Create the package object
                SocketMessage socketMessage = new SocketMessage();
                socketMessage.Socket = handler;

                // Read the package
                handler.BeginReceive(socketMessage.Buffer, 0, socketMessage.Buffer.Length, SocketFlags.None, ReceiveCallback, socketMessage);
            }
            catch (Exception ex)
            {
                OnException?.Invoke(ex);
            }
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                HttpRequest request = null;
                HttpResponse response = null;
                HttpConnectionInfo info = null;

                // Retrieve the package
                SocketMessage socketMessage = (SocketMessage)result.AsyncState;
                Socket handler = socketMessage.Socket;
                bool fullRequestReceived = false;

                // Read it
                int bytesRead = handler.EndReceive(result);

                if (bytesRead > 0)
                {
                    socketMessage.Data = socketMessage.Data.Push(socketMessage.Buffer.Slice(0, bytesRead));
                }
                else
                {
                    // If no bytes are sent anymore it means the connection got abrubtly closed from the client
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                    return;
                }

                // Try and parse what we already got to see if the full request was received in bytes
                try
                {
                    request = new HttpRequest(socketMessage.Data, false);
                    int bodyLength = request.Headers.ContentLength;

                    if (socketMessage.Data.Length >= bodyLength + request.GenerateRaw().Length && request.AllHeadersReceived)
                    {
                        fullRequestReceived = true;
                    }
                }
                catch (Exception)
                {
                    // Just ignore the exception
                }

                // Either keep receiving or stop and process the request
                if (!fullRequestReceived)
                {
                    handler.BeginReceive(socketMessage.Buffer, 0, socketMessage.Buffer.Length, SocketFlags.None, ReceiveCallback, socketMessage);
                }
                else
                {
                    bool keepAlive = false;

                    // Setup the request, response and info object
                    info = new HttpConnectionInfo(socketMessage.Socket);
                    request = new HttpRequest(socketMessage.Data);
                    response = new HttpResponse(socketMessage.Socket);

                    // Ugly to put this here but we need the check to know wether or not the socket needs to be closed or not
                    // once the socket has been sent
                    if (request.Headers.Connection != null)
                    {
                        keepAlive = request.Headers.Connection.Split(',').Any(x => x.ToLower().Trim() == "keep-alive");
                    }

                    try
                    {
                        // Before anything else, check if the client is even allowed to connect
                        if (!CheckFilter(info.IPAddress))
                        {
                            OnRequestBlocked?.Invoke(request, response, info);
                            return;
                        }

                        // Handle the request
                        OnRequest?.Invoke(request, response, info);
                    }
                    catch (HttpException ex)
                    {
                        OnHttpError?.Invoke(ex.Status, ex.Message, request, response, info);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            info = new HttpConnectionInfo(socketMessage.Socket);
                            response = new HttpResponse(socketMessage.Socket);

                            // We need to check if the socket itself did not cause the exception
                            // Otherwise the response object is utterly useless
                            // We can do this easily by requesting the ip address from the connection info object
                            // The socket needs to be open for this to succeed
                            var ip = info.IPAddress;

                            // If the above succeeded continue
                            OnHttpError?.Invoke(HttpStatusCode.InternalServerError, "Something went wrong", request, response, info);
                            OnException?.Invoke(ex);
                        }
                        catch (Exception)
                        {
                            OnException?.Invoke(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnException?.Invoke(ex);
            }
        }

        private bool CheckFilter(IPAddress iPAddress)
        {
            // Only allow access from ip addresses listed in this file
            if (File.Exists("whitelist.dat"))
            {
                return File.ReadAllLines("whitelist.dat").Any(x => x == iPAddress.ToString());
            }

            // Do not allow access to ip addresses listed in this file
            if (File.Exists("blacklist.dat"))
            {
                return File.ReadAllLines("blacklist.dat").Any(x => x != iPAddress.ToString());
            }

            return true;
        }

        /* EVENTS */
        public delegate void OnRequestDelegate(HttpRequest request, HttpResponse response, HttpConnectionInfo info);
        public delegate void OnRequestBlockedDelegate(HttpRequest request, HttpResponse response, HttpConnectionInfo info);
        public delegate void OnExceptionDelegate(Exception ex);
        public delegate void OnHttpErrorDelegate(HttpStatusCode status, string error, HttpRequest request, HttpResponse response, HttpConnectionInfo info);
        public event OnRequestDelegate OnRequest;
        public event OnRequestBlockedDelegate OnRequestBlocked;
        public event OnExceptionDelegate OnException;
        public event OnHttpErrorDelegate OnHttpError;
    }
}