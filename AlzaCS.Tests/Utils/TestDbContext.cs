using AlzaCS.Data;
using Microsoft.EntityFrameworkCore;

namespace AlzaCS.Tests.Utils
{
    public class TestDbContext : AppDbContext
    {
        public TestDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
