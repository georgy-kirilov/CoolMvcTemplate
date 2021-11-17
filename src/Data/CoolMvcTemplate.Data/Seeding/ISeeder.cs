namespace CoolMvcTemplate.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(AppDbContext dbContext, IServiceProvider serviceProvider);
    }
}
