using Domain.Exceptions.Base;

namespace Application.Exceptions;

public sealed class ValidationException : BadRequestException
{
    public Dictionary<string, string[]> Erorrs { get; }

    public ValidationException(Dictionary<string, string[]> erorrs) : base("Validation errors occurred")
    {
        Erorrs = erorrs;
    }
}
