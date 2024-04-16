namespace Domestos.Persistence.Interfaces;

using Domestos.Persistence.Models;

public interface IProductReadService
{
    Task<IReadOnlyList<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default);
}