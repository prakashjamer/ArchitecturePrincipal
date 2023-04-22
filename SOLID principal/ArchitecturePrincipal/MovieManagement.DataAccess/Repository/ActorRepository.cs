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
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        private readonly MovieManagementDbContext dbContext;

        public ActorRepository(MovieManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Actor> GetActorsWithMovies()
        {
            return dbContext.Actors.Include(c=>c.Movies).ToList();


        }
    }
}
