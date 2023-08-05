using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MovieManagementBusiness.DTO;
using MovieManagementBusiness.Interface;
using MovieManagementDomain.Interface.Repository;
using Newtonsoft.Json;

namespace MovieManagement.Controllers
{
    [Route("api/[controller]")]
    // [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;
        private readonly IDistributedCache distributedCache;

        public ILogger<MovieController> Logger { get; }
        public IUnitOfWork UnitOfWork { get; }
        public MovieController(ILogger<MovieController> logger, IUnitOfWork unitOfWork, IMovieService movieService, IDistributedCache distributedCache)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
            this.movieService = movieService;
            this.distributedCache = distributedCache;
        }
        [HttpGet]
        [Route("GetAllMovies")]
        public async Task<ActionResult> GetAllMovies()
        {
            Logger.LogInformation("Code  start  for  get all  moview ");
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("abb")))
            {
                HttpContext.Session.SetString("abb", "prakashjamer");
            }
            var t = HttpContext.Session.GetString("abb");
            dynamic result1 = await distributedCache.GetStringAsync("MovieData");
            //if (distributedCache.("MovieData")==null && distributedCache.GetString("MovieData").Length==0)
            //{
            if (result1 == null)
            {
                var tomorrow = DateTime.Now.Date.AddDays(1);
                var remseconds = tomorrow.Subtract(DateTime.Now).TotalSeconds;
                var result = await movieService.GetAllMovies();
                var distributioncacheOption = new DistributedCacheEntryOptions();
                distributioncacheOption.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(remseconds);
                distributioncacheOption.SlidingExpiration = TimeSpan.FromHours(1);
                var jsonData = JsonConvert.SerializeObject(result);
                await distributedCache.SetStringAsync("MovieData", jsonData, distributioncacheOption);
                //var result=await  UnitOfWork.MovieRepo.GetAll().ToListAsync();
                return Ok(result);
            }
            else
            {
                var result = await distributedCache.GetStringAsync("MovieData");
                return Ok(result);
            }

        }
        //public static bool KeyExistsAsType(this RedisClient redisClient, string key, RedisKeyType keyType)
        //{
        //    bool keyExistsAsType =
        //    redisClient.GetEntryType(key) == keyType ?
        //    true : false;
        //    return keyExistsAsType;
        //}
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetMoviesByID([FromRoute] int id)
        {
            var t = HttpContext.Session.GetString("abb");
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
