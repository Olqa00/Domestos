namespace Domestos.Domain.Exceptions;

public abstract class DomainException : Exception
{
    protected DomainException(string message, Exception? innerException = default)
        : base(message, innerException)
    {
    }

    public abstract string Code { get; }
}
