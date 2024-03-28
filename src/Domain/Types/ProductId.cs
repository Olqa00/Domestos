namespace Domestos.Domain.Types;

public record struct ProductId
{
    public Guid Value { get; private init; }

    public ProductId(Guid value)
    {
        this.Value = value;
    }
}
