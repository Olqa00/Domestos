namespace Domestos.Persistence.QueryHandlers;

using Domestos.Application.Products.ViewModels;
using Domestos.Application.Products.Queries;
using Domestos.Persistence.Interfaces;
using MediatR;
using ProductsResult = System.Collections.Generic.IReadOnlyList<Domestos.Application.Products.ViewModels.Product>;

internal sealed class GetProductsHandler(IProductReadService service) : IRequestHandler<GetProducts, ProductsResult>
{
    public async Task<ProductsResult> Handle(GetProducts request, CancellationToken cancellationToken)
    {
        var products = await service.GetAllProductsAsync(cancellationToken);

        var results = products.Select(product => new Product()
        {
            Id = product.Id,
            Name = product.Name,
        })
        .ToList()
        .AsReadOnly();

        return await Task.FromResult(results);
    }
}
