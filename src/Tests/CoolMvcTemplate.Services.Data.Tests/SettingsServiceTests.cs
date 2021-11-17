namespace CoolMvcTemplate.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolMvcTemplate.Data;
    using CoolMvcTemplate.Data.Common.Repositories;
    using CoolMvcTemplate.Data.Models;
    using CoolMvcTemplate.Data.Repositories;

    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class SettingsServiceTests
    {
        [Fact]
        public void GetCountShouldReturnCorrectNumber()
        {
            var repository = new Mock<IDeletableRepository<Setting>>();
            repository.Setup(r => r.All()).Returns(new List<Setting>
                                                        {
                                                            new Setting(),
                                                            new Setting(),
                                                            new Setting(),
                                                        }.AsQueryable());
            var service = new SettingsService(repository.Object);
            Assert.Equal(3, service.GetCount());
            repository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "SettingsTestDb").Options;
            using var dbContext = new AppDbContext(options);
            dbContext.Settings.Add(new Setting());
            dbContext.Settings.Add(new Setting());
            dbContext.Settings.Add(new Setting());
            await dbContext.SaveChangesAsync();

            using var repository = new EFDeletableRepository<Setting>(dbContext);
            var service = new SettingsService(repository);
            Assert.Equal(3, service.GetCount());
        }
    }
}
