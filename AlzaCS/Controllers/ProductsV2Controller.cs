using AlzaCS.Data;
using AlzaCS.Models;
using AlzaCS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlzaCS.Controllers;

[ApiController]
[Route("api/v2/products")]
public class ProductsV2Controller : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsV2Controller(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetPaged(int page = 1, int pageSize = 10)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;

        var items = await _context.Products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return Ok(items);
    }

    [HttpPost("{id}/stock")]
    public IActionResult EnqueueStockUpdate(int id, [FromBody] StockUpdateRequest request)
    {
        StockUpdateQueueService.Enqueue(new()
        {
            ProductId = id,
            Quantity = request.Quantity
        });

        return Accepted(new { Message = $"Stock update for product {id} enqueued." });
    }

}
