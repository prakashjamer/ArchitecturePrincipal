using MovieManagement.DataAccess.Context;
using MovieManagementDomain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieManagementDbContext _dbContext { get; }
        public UnitOfWork(MovieManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            ActorRepo = new ActorRepository(dbContext);
            MovieRepo = new MovieRepository(dbContext);
            BiographyRepo = new BiographyRepository(dbContext);
        }
        public IActorRepository ActorRepo { get; private set; }
        public IMovieRepository MovieRepo { get; private set; }
        public IBiographyRepository BiographyRepo { get; private set; }


        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
