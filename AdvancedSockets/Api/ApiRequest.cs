using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AdvancedSockets;
using Newtonsoft.Json;

namespace AdvancedSockets.Api
{
    public class ApiRequest
    {
        private string url;
        private string token;

        public ApiRequest(string url, string token = null)
        {
            this.url = url;
            this.token = token;
        }

        public ApiResponse Get(string path)
        {
            return Send(HttpMethod.Get, path);
        }
        public ApiResponse Post(string path, Dictionary<string, string> body)
        {
            return Send(HttpMethod.Post, path, body);
        }
        public ApiResponse Post(string path, object body = null)
        {
            return Send(HttpMethod.Post, path, body);
        }
        public ApiResponse Put(string path, Dictionary<string, string> body)
        {
            return Send(HttpMethod.Put, path, body);
        }
        public ApiResponse Put(string path, object body = null)
        {
            return Send(HttpMethod.Put, path, body);
        }
        public ApiResponse Delete(string path, Dictionary<string, string> body)
        {
            return Send(HttpMethod.Delete, path, body);
        }
        public ApiResponse Delete(string path, object body = null)
        {
            return Send(HttpMethod.Delete, path, body);
        }

        private ApiResponse Send(HttpMethod method, string path, object body = null)
        {
            try
            {
                var client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);

                var httpRequest = new HttpRequestMessage(method, url + path);
                
                if (token != null)
                {
                    httpRequest.Headers.Add("Authorization", token);
                }

                if (body != null)
                {
                    if (body.GetType() == typeof(string))
                    {
                        httpRequest.Content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
                    }
                    else if (body.GetType() == typeof(Dictionary<string, string>))
                    {
                        httpRequest.Content = new FormUrlEncodedContent((Dictionary<string, string>)body);
                    }
                    else
                    {
                        httpRequest.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                    }                    
                }

                var httpResponse = client.SendAsync(httpRequest).GetAwaiter().GetResult();          
                var responseStatus = httpResponse.StatusCode;
                var responseBody = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return new ApiResponse(responseStatus, responseBody);
            }
            catch (HttpRequestException)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, "Unable to connect to server");
            }
            catch (TaskCanceledException)
            {
                throw new HttpException(HttpStatusCode.RequestTimeout, "Unable to connect to server. A network timeout occured.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
