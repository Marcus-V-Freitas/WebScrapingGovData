using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using Data;
using Data.Repository;
using Domain.Interfaces;
using IoC.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace IoC.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExtractGovContext>(options =>
            {
                string connection = configuration.GetConnectionString("DefaultConnection");
                options.UseMySql(connection, ServerVersion.AutoDetect(connection),
                 x => x.MigrationsAssembly(typeof(ExtractGovContext).Assembly.FullName));
            });

            services.AddScoped<IExtractGovWebDataRepository, ExtractGovWebDataRepository>();
            services.AddScoped<IExtractGovWebDataService, ExtractGovWebDataService>();

            services.AddTransient<GlobalExceptionHandlerMiddleware>();
            services.AddScoped<HttpClient>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }

        public static void UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}