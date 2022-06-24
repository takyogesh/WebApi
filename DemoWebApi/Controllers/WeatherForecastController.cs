using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController>? _logger;
        private List<Employee>? employees;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("hello")]
        public ActionResult hello()
        {
            return Ok("Its Demo Web Api");
        }
        [HttpGet("emp")]
        public ActionResult Employee()
        {
            employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, Name = "yogesh", Address = "jalgaon" });
            employees.Add(new Employee { Id = 2, Name = "vinay", Address = "pune" });
            return Ok(employees);
        }
    }
}