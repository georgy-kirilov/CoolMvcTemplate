﻿namespace CoolMvcTemplate.Data.Repositories
{
    using System;
    using System.Linq;

    using CoolMvcTemplate.Data.Common.Models;
    using CoolMvcTemplate.Data.Common.Repositories;

    using Microsoft.EntityFrameworkCore;

    public class EFDeletableRepository<TEntity> : EFRepository<TEntity>, IDeletableRepository<TEntity>
        where TEntity : class, IDeletable
    {
        public EFDeletableRepository(AppDbContext context)
            : base(context)
        {
        }

        public override IQueryable<TEntity> All() => base.All().Where(x => !x.IsDeleted);

        public override IQueryable<TEntity> AllAsNoTracking() => base.AllAsNoTracking().Where(x => !x.IsDeleted);

        public IQueryable<TEntity> AllWithDeleted() => base.All().IgnoreQueryFilters();

        public IQueryable<TEntity> AllAsNoTrackingWithDeleted() => base.AllAsNoTracking().IgnoreQueryFilters();

        public void HardDelete(TEntity entity) => base.Delete(entity);

        public void Undelete(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;
            this.Update(entity);
        }

        public override void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            this.Update(entity);
        }
    }
}
