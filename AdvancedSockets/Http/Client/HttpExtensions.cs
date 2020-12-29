using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AdvancedSockets.Http.Client
{
    public static class HttpExtensions
    {
        public static void Send(this HttpRequest request)
        {
            request.Socket.Send(request.GenerateRaw());
        }
    }
}