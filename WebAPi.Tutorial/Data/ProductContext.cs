using Microsoft.EntityFrameworkCore;

namespace WebAPi.Tutorial.Data
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

       
    }
}
