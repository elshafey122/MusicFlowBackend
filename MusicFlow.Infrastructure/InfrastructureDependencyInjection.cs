using Microsoft.Extensions.DependencyInjection;
using MusicFlow.Application.Interfaces;
using MusicFlow.Infrastructure.Service;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
