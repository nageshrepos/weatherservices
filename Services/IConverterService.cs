using TemparatureConverter.Models;
using System.Collections.Generic;

namespace TemparatureConverter.Services
{
    public interface IConverterService
    {
        public double GetKlevin(double celsius);
        public double GetFahrenheit(double celsius);
    }
}
