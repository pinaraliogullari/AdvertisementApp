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

        public async Task<List<Product>> GetAllAsync() =>

             await Table.AsNoTracking().ToListAsync();


        public async Task<Product> GetByIdAsync(int id)=>
             await Table.SingleOrDefaultAsync(x => x.Id == id);

       
    }
}
