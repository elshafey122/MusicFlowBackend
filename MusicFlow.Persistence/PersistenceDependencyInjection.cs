using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicFlow.Application.Interfaces;
using MusicFlow.Domain.Entites;
using MusicFlow.Persistence.IRepositories;
using MusicFlow.Persistence.Repositories;
using MusicFlow.Persistence.Services;
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

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();



            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped(typeof(IRepositroy<>), typeof(Repository<>));
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IDspRepository, DspRepository>();
            services.AddScoped<ITrackDistRepository, TrackDistRepository>();




            return services;
        }
    }
}