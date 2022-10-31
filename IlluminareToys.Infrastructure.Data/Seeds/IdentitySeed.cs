using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace IlluminareToys.Infrastructure.Data.Seeds
{
    public class IdentitySeed
    {
        public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Basic.ToString()));
            await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Admin.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            //Seed Default User
            var defaultUser = new User
            {
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                FirstName = "Fulano",
                LastName = "Silva",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "User created by seed",
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    var result = await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                        await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                    };

                }
            }
        }

    }
}
