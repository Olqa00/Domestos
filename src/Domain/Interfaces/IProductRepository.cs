namespace Domestos.Domain.Interfaces;

using Domestos.Domain.Entities;

public interface IProductRepository
{
    Task CreateAsync(ProductEntity productEntity, CancellationToken cancellationToken = default);
}
