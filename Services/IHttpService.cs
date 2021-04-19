using System.Net.Http;

namespace TemparatureConverter.Services
{
    public interface IHttpService
    {
        public HttpResponseMessage GetResponse(string url);
    }
}
