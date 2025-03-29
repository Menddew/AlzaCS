using AlzaCS.Models;
using Microsoft.EntityFrameworkCore;

namespace AlzaCS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "T-Shirt",
                    ImageUrl = "https://example.com/tshirt.jpg",
                    Price = 19.99m,
                    Description = "A stylish T-shirt",
                    Quantity = 100
                },
                new Product
                {
                    Id = 2,
                    Name = "Cap",
                    ImageUrl = "https://example.com/cap.jpg",
                    Price = 9.99m,
                    Description = "A cool cap",
                    Quantity = 50
                }
            );
        }
    }
}
