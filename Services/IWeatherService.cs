using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemparatureConverter.Models;

namespace TemparatureConverter.Services
{
    public interface IWeatherService
    {
        object GetCurrentWeather(string city, string country);
    }
}
