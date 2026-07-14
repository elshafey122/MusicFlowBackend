using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MusicFlow.Application.Features.Artist.Commands.Handler;
using ProductService.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProductService.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(ArtistMappingProfile));
            services.AddAutoMapper(typeof(TrackMappingProfile));

            return services;
        }
    }
}
