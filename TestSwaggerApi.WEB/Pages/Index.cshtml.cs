using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestSwaggerApi.Client;

namespace TestSwaggerApi.WEB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly WeatherForecastClient weatherForecastClient;

        public IndexModel(
            ILogger<IndexModel> logger,
            WeatherForecastClient weatherForecast)
        {
            _logger = logger;
            this.weatherForecastClient = weatherForecast;
        }

        public ICollection<WeatherForecast> Weather { get; private set; }

        public async Task OnGet()
        {
            this.Weather = await this.weatherForecastClient.GetAsync();
        }
    }
}
