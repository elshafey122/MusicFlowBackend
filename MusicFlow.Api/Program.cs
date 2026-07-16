
using Microsoft.AspNetCore.Builder;
using MusicFlow.Persistence.SeedData;
using ProductService.Application;
using ProductService.Infrastructure;

namespace MusicFlow.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();

            

            ApiDependencyInjection.AddApiependency(builder.Services,builder.Configuration);
            PersistenceDependencyInjection.AddPersistenceDI(builder.Services,builder.Configuration);
            ApplicationDependencyInjection.AddApplicationDI(builder.Services);
            InfrastructureDependencyInjection.AddInfrastructureDI(builder.Services);

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                await SeedUsersRoles.SeedAsync(services);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
