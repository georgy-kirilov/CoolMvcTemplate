namespace CoolMvcTemplate.Data.Common.Repositories
{
    using System.Linq;

    using CoolMvcTemplate.Data.Common.Models;

    public interface IDeletableRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
