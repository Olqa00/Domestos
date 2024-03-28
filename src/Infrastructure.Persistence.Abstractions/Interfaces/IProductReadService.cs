namespace Domestos.Infrastructure.Persistence.Interfaces;

using Domestos.Infrastructure.Persistence.Models;

public interface IProductReadService
{
    Task<IReadOnlyList<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default);
}