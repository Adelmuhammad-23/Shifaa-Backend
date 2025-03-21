using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShifaaAPI.Enums;
using ShifaaAPI.Models.Identity;

namespace ShifaaAPI.Seeders
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<Role> roleManager)
        {
            var CheckRole = await roleManager.Roles.SingleOrDefaultAsync(n => n.Name == DefaultRoles.Admin.ToString());
            if (CheckRole is null)
            {
                var adminRole = new Role { Name = DefaultRoles.Admin.ToString() };

                await roleManager.CreateAsync(adminRole);
            }
        }
    }
}
