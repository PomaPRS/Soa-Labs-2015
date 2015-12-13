using System;
using System.Net.Http;
using GodLib.Entities;

namespace GodLib.Web
{
    public class HttpMessenger : IHttpMessenger
    {
        private readonly HttpMessengerSettings _settings;

        public HttpMessenger(HttpMessengerSettings settings)
        {
            _settings = settings;
        }

        public Response SendGet(string method)
        {
            var result = GetHttpClient().GetAsync(method).Result;
            return GetResponse(result);
        }

        public Response SendPost(string method, byte[] requestData)
        {
            var result = GetHttpClient().PostAsync(method, new ByteArrayContent(requestData)).Result;
            return GetResponse(result);
        }

        private HttpClient GetHttpClient()
        {
            var uri = string.Format("{0}:{1}", _settings.Host, _settings.Port);
            return new HttpClient()
            {
                BaseAddress = new Uri(uri)
            };
        }

        private Response GetResponse(HttpResponseMessage result)
        {
            return new Response()
            {
                StatusCode = result.StatusCode,
                Data = result.Content.ReadAsStringAsync().Result
            };
        }
    }
}