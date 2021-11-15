namespace CoolMvcTemplate.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using CoolMvcTemplate.Common;
    using CoolMvcTemplate.Data.Models;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();

            await SeedRoleAsync(roleManager, GlobalConstants.AdministratorRoleName);
        }

        private static async Task SeedRoleAsync(RoleManager<AppRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                var result = await roleManager.CreateAsync(new AppRole(roleName));

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}