using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementDomain.Interface.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IActorRepository ActorRepo { get; }
        IMovieRepository MovieRepo { get; }
        IBiographyRepository BiographyRepo { get; }
        int Save();

    }
}
