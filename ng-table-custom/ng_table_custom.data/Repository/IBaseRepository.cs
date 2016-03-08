namespace ng_table_custom.data.Repository
{
    using Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBaseRepository<T> : IDisposable where T : IEntity
    {
        IQueryable<T> QueryAll { get; }
        IQueryable<T> NotTracking { get; }
        Task<bool> Insert(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Delete(int Id);
        Task<bool> Update(T entity);
        Task<bool> InsertOrUpdate(T entity);
        Task<T> FindById(int Id);
        IQueryable<T> FindByPredicate(string predicate);
    }
}
