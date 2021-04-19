using TemparatureConverter.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemparatureConverter.Services
{
    public class ConverterService : IConverterService
    {
        public ConverterService()
        {
            
        }

        public double GetKlevin(double celsius)
        {
            return celsius + 273.15;
        }

        public double GetFahrenheit(double celsius)
        {
            return celsius * 18 / 10 + 32;
        }
        
    }
}
