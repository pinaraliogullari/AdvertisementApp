using AdvertisementApp.Data.Interfaces;
using AdvertisementApp.Entities;

namespace AdvertisementApp.Data.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T:BaseEntity;
        Task SaveChangesAsync();

    }
}
