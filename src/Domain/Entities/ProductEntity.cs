namespace Domestos.Domain.Entities;

using Domestos.Domain.Exceptions;
using Domestos.Domain.Types;

public sealed class ProductEntity
{
    public ProductId Id { get; private init; }
    public string Name { get; private set; } = string.Empty;

    public ProductEntity(ProductId id, string name)
    {
        this.Id = id;
        this.SetName(name);
    }

    private void SetName(string name)
    {
        var trimmedName = name.Trim();

        if (string.IsNullOrWhiteSpace(trimmedName))
        {
            throw new IncorrectNameException(name);
        }

        this.Name = trimmedName;
    }
}
