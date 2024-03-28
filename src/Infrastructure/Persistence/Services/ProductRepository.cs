namespace Domestos.Infrastructure.Persistence.Services;

using Domestos.Domain.Entities;
using Domestos.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

internal class ProductRepository : IProductRepository
{
    public Task CreateAsync(ProductEntity productEntity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
