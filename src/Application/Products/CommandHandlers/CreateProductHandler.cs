namespace Domestos.Application.Products.CommandHandlers;

using Domestos.Application.Products.Commands;
using Domestos.Domain.Entities;
using Domestos.Domain.Interfaces;
using Domestos.Domain.Types;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

internal sealed class CreateProductHandler : IRequestHandler<CreateProduct>
{
    private readonly IProductRepository repository;

    public CreateProductHandler(IProductRepository repository)
    {
        this.repository = repository;
    }

    public async Task Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        var productId = new ProductId(request.Id);
        var productEntity = new ProductEntity(productId, request.Name);

        await this.repository.CreateAsync(productEntity, cancellationToken);
    }
}
