using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicFlow.Persistence.IRepositories;
using MusicFlow.Persistence.Repositories;
using ProductService.Persistence;
using ProductService.Persistence.IRepositories;
using ProductService.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Infrastructure
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistenceDI(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

            //services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped(typeof(IRepositroy<>), typeof(Repository<>));
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();


            return services;
        }
    }
}