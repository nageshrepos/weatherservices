using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TemparatureConverter.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;
        public HttpService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://api.weatherbit.io/v2.0/");            
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
        }

        public HttpResponseMessage GetResponse(string endPoint)
        {
            var apiKey = "&key=9e60693a948541f9be8c5caece61199f";
              var request = new HttpRequestMessage(
               HttpMethod.Get,
               endPoint + apiKey);            
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
        }
    }
}
