﻿using MovieManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementDomain.Interface.Repository
{
    public interface IMovieRepository:IGenericRepository<Movie>
    {
        IQueryable<Movie> GetAllMovies();
    }
}
