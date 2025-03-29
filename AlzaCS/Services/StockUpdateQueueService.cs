using AlzaCS.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace AlzaCS.Services;

public class StockUpdateRequestItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class StockUpdateQueueService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<StockUpdateQueueService> _logger;
    private static readonly Channel<StockUpdateRequestItem> _channel = Channel.CreateUnbounded<StockUpdateRequestItem>();

    public StockUpdateQueueService(IServiceProvider serviceProvider, ILogger<StockUpdateQueueService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public static void Enqueue(StockUpdateRequestItem request)
    {
        _channel.Writer.TryWrite(request);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var item in _channel.Reader.ReadAllAsync(stoppingToken))
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var product = await db.Products.FirstOrDefaultAsync(p => p.Id == item.ProductId, stoppingToken);
                if (product is not null)
                {
                    product.Quantity = item.Quantity;
                    await db.SaveChangesAsync(stoppingToken);
                    _logger.LogInformation("Updated stock for product {ProductId} to {Quantity}", item.ProductId, item.Quantity);
                }
                else
                {
                    _logger.LogWarning("Product with ID {ProductId} not found", item.ProductId);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing stock update for product {ProductId}", item.ProductId);
            }
        }
    }
}
