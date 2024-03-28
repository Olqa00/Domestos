using Domestos.Domain.Constants;

namespace Domestos.Domain.Exceptions;

public sealed class IncorrectNameException : DomainException
{
    public IncorrectNameException(string message, Exception? innerException = default)
        : base(message, innerException)
    {

    }

    public override string Code => DomainErrorCode.INVALID_NAME;
}
