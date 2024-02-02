using Microsoft.AspNetCore.Mvc;

namespace TestProblemDetailsService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			ModelState.AddModelError("TestErrorKey", "Test Error Message");
			throw new ValidationException(ModelState);
		}
	}
}
