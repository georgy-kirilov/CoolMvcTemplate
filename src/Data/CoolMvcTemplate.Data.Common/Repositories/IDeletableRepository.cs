namespace CoolMvcTemplate.Data.Common.Repositories
{
    using CoolMvcTemplate.Data.Common.Models;

    public interface IDeletableRepository<TEntity> : IRepository<TEntity> where TEntity : class, IDeletable
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
