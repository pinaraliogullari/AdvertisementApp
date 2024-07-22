using Microsoft.EntityFrameworkCore;
using WebAPi.Tutorial.Data;
using WebAPi.Tutorial.Interfaces;

namespace WebAPi.Tutorial.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public DbSet<Product> Table => _context.Products;

        public async Task<Product> CreateAsync(Product product)
        {
            await Table.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllAsync() =>

             await Table.AsNoTracking().ToListAsync();


        public async Task<Product> GetByIdAsync(int id) =>
             await Table.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(int id)
        {
            var removedEntity = await Table.FindAsync(id);
            Table.Remove(removedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var unchanged = await Table.FindAsync(product.Id);
            _context.Entry(unchanged).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync(true);
        }
    }
}
