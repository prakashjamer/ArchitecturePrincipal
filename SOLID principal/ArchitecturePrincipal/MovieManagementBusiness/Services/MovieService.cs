using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieManagementBusiness.DTO;
using MovieManagementBusiness.Interface;
using MovieManagementDomain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementBusiness.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper mapper;

        public ILogger<MovieService> logger { get; }
        public IMovieRepository movieRepository { get; }
        public MovieService(ILogger<MovieService> logger, IMovieRepository movieRepository, IMapper mapper)
        {
            this.logger = logger;
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }



        public async Task<List<MovieDTO>> GetAllMovies()
        {
            try
            {
                logger.LogError($"Method start {nameof(GetAllMovies)}");
                using (var transaction = movieRepository.BeginTransactionAsync().Result)
                {
                    var movies = await movieRepository.GetAllMovies().ToListAsync();
                    if (movies.Count > 0)
                    {
                        return mapper.Map<List<MovieDTO>>(movies);
                    }
                    movieRepository.CommitTransactionAsync(transaction).Wait();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error Occured  in {nameof(GetAllMovies)} Error Message : {ex.Message}");
            }
            return null;
        }
    }
}
