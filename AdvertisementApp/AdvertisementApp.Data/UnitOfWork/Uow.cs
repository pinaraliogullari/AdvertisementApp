using AdvertisementApp.Data.Contexts;
using AdvertisementApp.Data.Interfaces;
using AdvertisementApp.Data.Repositories;
using AdvertisementApp.Entities;

namespace AdvertisementApp.Data.UnitOfWork
{
    public class Uow:IUow
    {
        private readonly AdvertisementContext _context;

        public Uow(AdvertisementContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>()where T:BaseEntity=>
            new Repository<T>(_context);

        public async Task SaveChangesAsync()=>
            await _context.SaveChangesAsync();
         
    }
}
