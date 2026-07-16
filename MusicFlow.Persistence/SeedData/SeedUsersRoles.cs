using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MusicFlow.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Persistence.SeedData
{
    public static class SeedUsersRoles
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            // Create Roles
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            // Create Admin
            var admin = await userManager.FindByEmailAsync("admin@gmail.com");

            if (admin == null)
            {
                admin = new User
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            // Create User
            var user = await userManager.FindByEmailAsync("user@gmail.com");

            if (user == null)
            {
                user = new User
                {
                    UserName = "user",
                    Email = "user@gmail.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "User@123");
                await userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}
