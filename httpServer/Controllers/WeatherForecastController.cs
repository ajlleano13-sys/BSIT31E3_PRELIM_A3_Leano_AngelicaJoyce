using Microsoft.AspNetCore.Mvc;

namespace httpServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public IActionResult Post([FromBody] WeatherForecast forecast)
        {
            return Ok(forecast);
        }

        [HttpPut(Name = "PutWeatherForecast")]
        public IActionResult Put([FromBody] WeatherForecast forecast)
        {
            return Ok(forecast);
        }

        [HttpDelete(Name = "DeleteWeatherForecast")]
        public IActionResult Delete([FromBody] WeatherForecast forecast)
        {
            return Ok(forecast);

        }

    }
}
