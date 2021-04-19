using Newtonsoft.Json;
using System.Threading.Tasks;
using TemparatureConverter.Models;

namespace TemparatureConverter.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpService _httpService;

        public WeatherService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public object GetCurrentWeather(string city, string country)
        {
            object report = null;
            var response = _httpService.GetResponse("current?city="+city+"&country="+country);
            if (response.IsSuccessStatusCode)
            {
                Task<string> task = response.Content.ReadAsStringAsync();
                task.Wait();
                report = JsonConvert.DeserializeObject<object>(task.Result);               
            }
            return report;
        }
    }
}
