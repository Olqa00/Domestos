namespace Domestos.Infrastructure.Persistence.SqlServer.Services;

using Domestos.Infrastructure.Persistence.Interfaces;
using Domestos.Infrastructure.Persistence.Models;


internal sealed class ProductReadService : IProductReadService
{
    public async Task<IReadOnlyList<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default)
    {
        var products = new List<Product>
        {
            new ()
            {
                Id = Guid.NewGuid(), 
                Name = "domestos sql",
            },
        };
        await Task.CompletedTask;
        return products;
    }
}
