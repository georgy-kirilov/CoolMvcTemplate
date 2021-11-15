namespace CoolMvcTemplate.Data.Seeding
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;

    public class AppDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>()?.CreateLogger(typeof(AppDbContextSeeder));

            var seeders = new List<ISeeder>
            {
                new RolesSeeder()
            };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger?.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}