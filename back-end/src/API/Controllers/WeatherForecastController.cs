using Assets.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.API.Controllers
{
    public class WeatherForecastController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}
