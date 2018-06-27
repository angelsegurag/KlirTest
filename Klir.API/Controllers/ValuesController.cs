using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Klir.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private WeatherSqLiteContext _context;
        public ValuesController(WeatherSqLiteContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var rng = new Random();
            var number = Math.Round((decimal)rng.Next(0, 100), 0);
            //Randomly return an Error 
            if (number % 2 == 0) return Ok(
                    GetData()
                );
            else //Return error 500 
                return StatusCode(500);
        }

        private string GetData()
        {
            var ret = _context.Forecasts.ToList();
            return JsonConvert.SerializeObject(ret);
        }
    }
}
