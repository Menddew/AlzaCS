using Microsoft.EntityFrameworkCore;
using AlzaCS.Data;

namespace AlzaCS.Tests.Utils
{
    public static class TestDbHelper
    {
        public static AppDbContext GetInMemoryDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: dbName).Options;

            var db = new TestDbContext(options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }
    }
}
