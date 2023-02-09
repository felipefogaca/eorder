using eOrder.Domain.Common.Validation;

namespace eOrder.Domain.Exceptions
{
    public class EntityValidationException : Exception
    {

        public IReadOnlyCollection<ValidationError>? Errors { get; }

        public EntityValidationException(
            string? message,
            IReadOnlyCollection<ValidationError>? errors
            ) : base(message)
        => Errors = errors;

        public EntityValidationException(
            string? message
            ) : base(message)
        => Errors = new List<ValidationError>();
    }
}
