namespace Domestos.Application.Products.ViewModels;

public sealed record Product
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}