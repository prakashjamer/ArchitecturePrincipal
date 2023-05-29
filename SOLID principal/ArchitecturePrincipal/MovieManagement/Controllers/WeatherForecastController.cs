using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieManagementDomain.Interface.Repository;

namespace MovieManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _logger = logger;
            UnitOfWork = unitOfWork;
            this.configuration = configuration;
            // Configuration = configuration;
        }

        public IUnitOfWork UnitOfWork { get; }
      // public IConfiguration Configuration { get; }

        [HttpGet(Name = "GetActorwithMovies")]
        public ActionResult GetActorwithMovies()
        {
            var result = UnitOfWork.ActorRepo.GetActorsWithMovies();
            //return NotFound();
            //return CreatedAtRoute("",""); for POST 
            return Ok(result); // for GET ;
        }
        [HttpGet]
        [Route("GetEnvironmentInfo")]
        public ActionResult GetEnvironmentInfo()
        {
            var appsection = configuration.GetSection("CommonPoint").Value;
            var environmentType = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return Ok(environmentType);

        }
    }
}