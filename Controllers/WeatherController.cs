using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemparatureConverter.Models;
using TemparatureConverter.Services;

namespace TemparatureConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private IWeatherService _weatherService;
        private readonly ILogger<WeatherController> _logger;
       
        public WeatherController(ILogger<WeatherController> logger,
            IWeatherService weatherService)
        {
            _weatherService = weatherService;
            _logger = logger;           
        }

        [HttpGet]
        public object Get(string city="Melbourne",string country="Australia")
        {
            return _weatherService.GetCurrentWeather(city,country);
        }
       
    }
}