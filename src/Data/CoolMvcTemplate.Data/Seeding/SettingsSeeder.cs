﻿namespace CoolMvcTemplate.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolMvcTemplate.Data.Models;

    internal class SettingsSeeder : ISeeder
    {
        public async Task SeedAsync(AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Settings.Any())
            {
                return;
            }

            await dbContext.Settings.AddAsync(new Setting { Name = "Setting1", Value = "value1" });
        }
    }
}
