namespace Domestos.Infrastructure.Persistence.SqlServer.Services;

using Domestos.Domain.Entities;
using Domestos.Domain.Interfaces;

internal class ProductRepository : IProductRepository
{
    public Task CreateAsync(ProductEntity productEntity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}