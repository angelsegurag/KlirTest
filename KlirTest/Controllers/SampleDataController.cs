using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Klir.Angular.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private const string GET_WEATHER = "/api/values";

        private readonly IHttpClientFactory _httpClientFactory;

        public SampleDataController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Klir.Model.WeatherForecast>> WeatherForecasts()
        {
            var client = _httpClientFactory.CreateClient("Klir");

            var ret = await client.GetStringAsync(GET_WEATHER);

            return JsonConvert.DeserializeObject<IEnumerable<Klir.Model.WeatherForecast>>(ret);
        }
    }
}
