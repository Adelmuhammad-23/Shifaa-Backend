using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShifaaAPI.Enums;
using ShifaaAPI.Models.Identity;

namespace ShifaaAPI.Seeders
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<User> userManager)
        {
            var checkAdmin = await userManager.Users.SingleOrDefaultAsync(un => un.UserName == "superAdmin");

            if (checkAdmin is null)
            {
                var adminUser = new User()
                {
                    UserName = "superAdmin",
                    Email = "admin@project.com",
                    PhoneNumber = "01234567890",
                    Name = "Super Admin",
                    Password = "Dod2003122#",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                await userManager.CreateAsync(adminUser, adminUser.Password);
                await userManager.AddToRoleAsync(adminUser, DefaultRoles.Admin.ToString());
            }
        }
    }
}

