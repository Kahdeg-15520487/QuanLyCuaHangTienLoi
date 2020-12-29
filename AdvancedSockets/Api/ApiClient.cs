using System.Collections.Generic;
using Newtonsoft.Json;

namespace AdvancedSockets.Api
{
    public class ApiClient
    {
        private string url;

        public ApiClient(string url)
        {
            this.url = url;
        }

        public string Get(string path, string token)
        {
            ApiRequest request = new ApiRequest(url, token);
            ApiResponse response = request.Get(path);
            response.ThrowExceptionWhenBadStatus();
            return response.Body;
        }
        public T Get<T>(string path, string token)
        {
            return JsonConvert.DeserializeObject<T>(Get(path, token));
        }

        public string Post(string path, string token, object body)
        {
            ApiRequest request = new ApiRequest(url, token);
            ApiResponse response = request.Post(path, body);
            response.ThrowExceptionWhenBadStatus();
            return response.Body;
        }
        public string Post(string path, string token, Dictionary<string, string> data)
        {
            return Post(path, token, data);
        }
        public T Post<T>(string path, string token, object body)
        {
            return JsonConvert.DeserializeObject<T>(Post(path, token, body));
        }
        public T Post<T>(string path, string token, Dictionary<string, string> data)
        {
            return JsonConvert.DeserializeObject<T>(Post(path, token, data));
        }

        public string Put(string path, string token, object body)
        {
            ApiRequest request = new ApiRequest(url, token);
            ApiResponse response = request.Put(path, body);
            response.ThrowExceptionWhenBadStatus();
            return response.Body;
        }
        public string Put(string path, string token, Dictionary<string, string> data)
        {
            return Put(path, token, data);
        }
        public T Put<T>(string path, string token, object body)
        {
            return JsonConvert.DeserializeObject<T>(Put(path, token, body));
        }
        public T Put<T>(string path, string token, Dictionary<string, string> data)
        {
            return JsonConvert.DeserializeObject<T>(Put(path, token, data));
        }

        public string Delete(string path, string token, object body)
        {
            ApiRequest request = new ApiRequest(url, token);
            ApiResponse response = request.Delete(path, body);
            response.ThrowExceptionWhenBadStatus();
            return response.Body;
        }
        public string Delete(string path, string token, Dictionary<string, string> data)
        {
            return Delete(path, token, data);
        }
        public T Delete<T>(string path, string token, object body)
        {
            return JsonConvert.DeserializeObject<T>(Delete(path, token, body));
        }
        public T Delete<T>(string path, string token, Dictionary<string, string> data)
        {
            return JsonConvert.DeserializeObject<T>(Delete(path, token, data));
        }
    }
}
