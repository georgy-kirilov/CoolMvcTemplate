namespace CoolMvcTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CoolMvcTemplate.Data.Common.Repositories;
    using CoolMvcTemplate.Data.Models;
    using CoolMvcTemplate.Services.Mapping;

    public class SettingsService : ISettingsService
    {
        private readonly IDeletableRepository<Setting> settingsRepository;

        public SettingsService(IDeletableRepository<Setting> settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public int GetCount()
        {
            return this.settingsRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.settingsRepository.All().To<T>().ToList();
        }
    }
}
