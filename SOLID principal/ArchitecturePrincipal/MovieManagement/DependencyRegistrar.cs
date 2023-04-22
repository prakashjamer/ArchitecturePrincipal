using MovieManagement.Filters;
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
    }
}
