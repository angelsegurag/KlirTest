using System;
using System.ComponentModel.DataAnnotations;

namespace Klir.Model
{
    public class WeatherForecast
    {
        [Key]
        public string DateFormatted { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }

        public int TemperatureF
        {
            get
            {
                return 32 + (int)(TemperatureC / 0.5556);
            }
        }
    }
}
