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
        public MovieRepository(MovieManagementDbContext dbContext) : base(dbContext)
        {
                
        }
    }
}
