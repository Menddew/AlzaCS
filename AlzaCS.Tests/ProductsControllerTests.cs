using AlzaCS.Controllers;
using AlzaCS.Models;
using AlzaCS.Tests.Utils;
using Microsoft.AspNetCore.Mvc;

namespace AlzaCS.Tests
{
    public class ProductsControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllProducts()
        {
            // Arrange
            var db = TestDbHelper.GetInMemoryDbContext("GetAllDb");
            db.Products.Add(new Product { Name = "Test", ImageUrl = "img", Quantity = 1 });
            await db.SaveChangesAsync();

            var controller = new ProductsController(db);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.NotNull(result.Value);
            Assert.Single(result.Value);
        }

        [Fact]
        public async Task GetById_ReturnsProduct_WhenExists()
        {
            var db = TestDbHelper.GetInMemoryDbContext("GetByIdDb");
            db.Products.Add(new Product { Id = 1, Name = "Test", ImageUrl = "img", Quantity = 5 });
            await db.SaveChangesAsync();

            var controller = new ProductsController(db);
            var result = await controller.GetById(1);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task Create_AddsProduct()
        {
            var db = TestDbHelper.GetInMemoryDbContext("CreateDb");
            var controller = new ProductsController(db);

            var request = new ProductCreateRequest
            {
                Name = "New Product",
                ImageUrl = "url"
            };

            var result = await controller.Create(request);

            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Single(db.Products.ToList());
        }

        [Fact]
        public async Task UpdateStock_ChangesQuantity()
        {
            var db = TestDbHelper.GetInMemoryDbContext("UpdateStockDb");
            db.Products.Add(new Product { Id = 1, Name = "Test", ImageUrl = "img", Quantity = 5 });
            await db.SaveChangesAsync();

            var controller = new ProductsController(db);
            var request = new StockUpdateRequest { Quantity = 42 };

            var result = await controller.UpdateStock(1, request);

            Assert.IsType<NoContentResult>(result);
            Assert.Equal(42, db.Products.First().Quantity);
        }
    }
}
