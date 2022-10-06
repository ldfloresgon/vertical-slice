using System.Runtime.Serialization;

namespace Vertical.Slice.Core;

[Serializable]
public class RequestValidationException : Exception
{
    private IEnumerable<ValidationError> _errors;
    public IEnumerable<ValidationError> Errors
    {
        get
        {
            return _errors;
        }
    }

    public RequestValidationException()
    {
    }

    public RequestValidationException(IEnumerable<ValidationError> errors) => _errors = errors;

    public RequestValidationException(string? message) : base(message)
    {
    }

    public RequestValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected RequestValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
