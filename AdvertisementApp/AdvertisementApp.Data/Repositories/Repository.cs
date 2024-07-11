using AdvertisementApp.Data.Contexts;
using AdvertisementApp.Data.Interfaces;
using AdvertisementApp.Entities;
using AdvertisementApp.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdvertisementApp.Data.Repositories
{

    #region Açıklamaaaaaaaaaaaaaaaaaaa
    //Aşağıdaki şekilde de getall işlemi yapılabilirdi ancak çok fazla if bloğu yazmamak iin metot overloadinge gitmek daha mantıklı
    //    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TKey>> selector = null, OrderByType orderByType = OrderByType.DESC)
    //{
    //    IQueryable<T> query = Table.AsNoTracking();

    //    if (predicate != null)
    //    {
    //        query = query.Where(predicate);
    //    }

    //    if (selector != null)
    //    {
    //        if (orderByType == OrderByType.ASC)
    //        {
    //            query = query.OrderBy(selector);
    //        }
    //        else
    //        {
    //            query = query.OrderByDescending(selector);
    //        }
    //    }

    //    return await query.ToListAsync();
    //}
    #endregion
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AdvertisementContext _context;

        public Repository(AdvertisementContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        //bütün veriyi getirme
        //bütün veriyi sıralı getirme
        //veriyi filtreli getirme
        //AsNoTracking()

        public async Task<List<T>> GetAllAsync() =>
             await Table.AsNoTracking().ToListAsync();


        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate) =>

           await Table.Where(predicate).AsNoTracking().ToListAsync();

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC) =>
            orderByType == OrderByType.ASC ? await Table.AsNoTracking().OrderBy(selector).ToListAsync() : await Table.AsNoTracking().OrderByDescending(selector).ToListAsync();

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC) =>
             orderByType == OrderByType.ASC ? await Table.Where(predicate).AsNoTracking().OrderBy(selector).ToListAsync() : await Table.Where(predicate).AsNoTracking().OrderByDescending(selector).ToListAsync();

        public async Task<T> FindAsync(object id) =>
            await Table.FindAsync(id);

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate, bool tracking) =>
            !tracking ? await Table.AsNoTracking().SingleOrDefaultAsync(predicate) : await Table.SingleOrDefaultAsync(predicate);

        public IQueryable<T> GetQuery() =>
             Table.AsQueryable();
        public void Remove(T entity) =>
            Table.Remove(entity);

        public async Task CreateAsync(T entity)
            => await Table.AddAsync(entity);

        public void Update(T entity, T unchanged) =>
            Table.Entry(unchanged).CurrentValues.SetValues(entity);
    }
}
