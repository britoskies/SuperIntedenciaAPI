using Microsoft.AspNetCore.Identity;
using PruebaTecnicaAPI.Core.Application.Enums;
using PruebaTecnicaAPI.Infrastructure.Identity.Entities;

namespace PruebaTecnicaAPI.Infrastructure.Identity.Seeds
{
    public class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new();
            defaultUser.UserName = "admin";
            defaultUser.Email = "admin_apiSB@gmail.com";
            defaultUser.FirstName = "John";
            defaultUser.LastName = "Doi";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(user => user.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null) 
                { 
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                }
            }
        }
    }
}