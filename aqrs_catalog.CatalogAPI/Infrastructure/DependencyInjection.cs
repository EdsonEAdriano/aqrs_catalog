using aqrs_catalog.CatalogAPI.Data;
using aqrs_catalog.CatalogAPI.Interfaces;
using aqrs_catalog.CatalogAPI.Mappings;
using aqrs_catalog.CatalogAPI.Refit.Interface;
using aqrs_catalog.CatalogAPI.Refit.Interfaces;
using aqrs_catalog.CatalogAPI.Repositories;
using aqrs_catalog.CatalogAPI.Services;
using Microsoft.EntityFrameworkCore;
using Refit;

namespace aqrs_catalog.CatalogAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connection = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ContextDbApplication>(options =>
                options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 23))));


            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<ICatalogService, CatalogService>();

            // Refit Services
            var apiBaseUrl = config["RefitServiceUri:ApiUrl"];

            services.AddRefitClient<ICategoryRefitService>().ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseUrl));
            services.AddRefitClient<IGenreRefitService>().ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseUrl));
            services.AddRefitClient<IMediaRefitService>().ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseUrl));
            services.AddRefitClient<IMediaTypeRefitService>().ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseUrl));
            services.AddRefitClient<IParticipantRefitService>().ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseUrl));
            services.AddRefitClient<IRatingRefitService>().ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseUrl));



            services.AddAutoMapper(typeof(DomainToDTOAndReverse));


            return services;
        }
    
        public static IServiceCollection AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });


            return services;
        }
    }
}
