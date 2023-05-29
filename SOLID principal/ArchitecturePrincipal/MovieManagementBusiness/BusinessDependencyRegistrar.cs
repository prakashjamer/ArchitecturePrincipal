using Microsoft.Extensions.DependencyInjection;
using MovieManagementBusiness.DTO;
using MovieManagementBusiness.Interface;
using MovieManagementBusiness.Services;
using MovieManagementDomain.Entities;
using MovieManagementDomain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementBusiness
{
    public static class BusinessDependencyRegistrar
    {
       
        public static IServiceCollection AddBusinessDepedency(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            return services;

        }

        
    }
}
