namespace CoolMvcTemplate.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using CoolMvcTemplate.Data.Common.Models;
    using CoolMvcTemplate.Data.Common.Repositories;

    public class EFDeletableEntityRepository<TEntity> : EFRepository<TEntity>, IDeletableRepository<TEntity> 
        where TEntity : class, IDeletable
    {
        public EFDeletableEntityRepository(AppDbContext context) : base(context)
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
            Update(entity);
        }

        public override void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            Update(entity);
        }
    }
}
