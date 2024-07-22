using WebAPi.Tutorial.Data;

namespace WebAPi.Tutorial.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product>CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task RemoveAsync(int id);
    }
}
