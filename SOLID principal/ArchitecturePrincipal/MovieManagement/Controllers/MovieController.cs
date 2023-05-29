using Microsoft.AspNetCore.Mvc;
using MovieManagementBusiness.DTO;
using MovieManagementBusiness.Interface;
using MovieManagementDomain.Interface.Repository;

namespace MovieManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;

        public ILogger<MovieController> Logger { get; }
        public IUnitOfWork UnitOfWork { get; }
        public MovieController(ILogger<MovieController> logger,IUnitOfWork unitOfWork,IMovieService movieService)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
            this.movieService = movieService;
        }
        [HttpGet]
        [Route("GetAllMovies")]
        public async Task<ActionResult> GetAllMovies()
        {
           var  result = await movieService.GetAllMovies();

        //var result=await  UnitOfWork.MovieRepo.GetAll().ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetMoviesByID([FromRoute] int id )
        {
            var result = UnitOfWork.MovieRepo.GetAll();
            return Ok(result);
        }
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateMovie([FromRoute] int id, [FromBody] MovieDTO request)
        {
            return Ok();
        }

    }
}
