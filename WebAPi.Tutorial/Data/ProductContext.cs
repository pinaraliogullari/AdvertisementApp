using Microsoft.EntityFrameworkCore;

namespace WebAPi.Tutorial.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(new Product[] {
                new() {Id = 1, Name = "Bilgisayar", Price = 45000, CreatedDate = DateTime.Now.AddDays(-3), Stock = 30 },
                new() {Id = 2, Name = "Telefon", Price = 20000, CreatedDate = DateTime.Now.AddDays(-30), Stock = 500 },
                new() {Id = 3, Name = "Klavye", Price = 5000, CreatedDate = DateTime.Now.AddDays(-60), Stock = 1000 },
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
