using System;

namespace WebAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public object  TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(12 / 0.5556);

        public string Summary { get; set; }
    }
}
