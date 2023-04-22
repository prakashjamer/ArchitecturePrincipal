using Microsoft.AspNetCore.Mvc;
using MovieManagementDomain.Interface.Repository;

namespace MovieManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        [HttpGet(Name = "GetActorwithMovies")]
        public  ActionResult GetActorwithMovies()
        {
            var  result= UnitOfWork.ActorRepo.GetActorsWithMovies();
            return Ok(result);
        }
    }
}