namespace Domestos.Application.Products.Queries;

using Domestos.Application.Products.ViewModels;
using MediatR;

public sealed record class GetProducts : IRequest<IReadOnlyList<Product>> { }
