using AutoMapper;
using TemparatureConverter.Models;
using TemparatureConverter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace TemparatureConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private IConverterService _converterService;
        private readonly ILogger<ConverterController> _logger;
       
        public ConverterController(ILogger<ConverterController> logger,
            IConverterService converterService)
        {
            _converterService = converterService;
            _logger = logger;           
        }

        [HttpGet]
        public TemparatureDto Get(double celsius)
        {
            TemparatureDto t = new TemparatureDto();
            t.Celcius = celsius;
            t.Fahrenheit = _converterService.GetFahrenheit(celsius);
            t.Klevin = _converterService.GetKlevin(celsius);
            return t;
        }      

    }
}