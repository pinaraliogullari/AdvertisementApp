using AdvertisementApp.Entities;
using AdvertisementApp.Shared.Enums;
using System.Linq.Expressions;

namespace AdvertisementApp.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);
        Task<T> FindAsync(object id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate, bool tracking);
        IQueryable<T> GetQuery();
        Task CreateAsync(T entity);
        void Update(T entity, T unchanged);
    }
}
