using System;

namespace RecordsInTheWild
{
    public record WeatherForecastDto
    {
        public DateTime Date { get; init; }

        public int TemperatureC { get; init; }

        public int TemperatureF { get; init; }

        public string Summary { get; init; }
    }
}