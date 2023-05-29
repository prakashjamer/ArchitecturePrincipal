using MovieManagement.DataAccess.Repository;
using MovieManagement.Filters;
using MovieManagementBusiness.Interface;
using MovieManagementBusiness.Services;
using MovieManagementDomain.Interface.Repository;
using Newtonsoft.Json.Serialization;
using System.Text.Json;

namespace MovieManagement
{
    public static class DependencyRegistrar
    {

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddControllers(

                option =>
                {
                    option.Filters.Add(typeof(HttpGlobalExceptionFilter));

                    option.Filters.Add(typeof(GlobalAuthorizationFilter));
                }

                ).AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    o.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    o.JsonSerializerOptions.WriteIndented = true;

                });
            services.AddCors(o => o.AddPolicy("CorsPolicy", c =>
            c.SetIsOriginAllowed((host) => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithExposedHeaders()));


            return services;
        }

        public static IServiceCollection AddDomainDepedency(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();

            return services;

        }
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;

        }
    }
}
