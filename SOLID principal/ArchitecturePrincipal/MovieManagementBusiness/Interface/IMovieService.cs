using MovieManagementBusiness.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementBusiness.Interface
{
    public interface IMovieService
    {
       public  Task<List<MovieDTO>> GetAllMovies();
    }
}
