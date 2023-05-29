using Microsoft.EntityFrameworkCore;
using MovieManagement.DataAccess.Context;
using MovieManagementDomain.Entities;
using MovieManagementDomain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Repository
{
    public class MovieRepository:GenericRepository<Movie>,IMovieRepository
    {
        private readonly MovieManagementDbContext dbContext;

        public MovieRepository(MovieManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<Movie> GetAllMovies()
        {
            return dbContext.Movies.Include(c=>c.Actors).AsNoTracking().AsQueryable();
        }
        public async Task<Movie> GetMovieWithActor(int movieID)
        {
            return await dbContext.Movies.Include(c=>c.Actors).Where(c => c.Id == movieID).FirstOrDefaultAsync();
        }
    }
}
