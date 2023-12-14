using System.Net;

using MediatR;

using Ria.Common.Validations;

namespace Ria.Common.Commands
{
    public abstract class CommandBase<TEntityResponse> : IRequest<ResponseBase<TEntityResponse>>
    {
        public ValidationResult ValidationResult { get; private set; } = new ValidationResult();

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }

        public void AddError(string propertyName, string errorMessage,
            HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            ValidationResult?.Errors.Add(new ValidationFailure(propertyName, errorMessage, httpStatusCode));
        }

        public void AddError(List<ValidationFailure> errors)
        {
            errors.ForEach(error => ValidationResult?.Errors.Add(error));
        }
    }

    public readonly struct ResponseBase<T>
    {
        public ResponseBase(ValidationResult validation)
            : this(default, validation)
        {
        }

        public ResponseBase(T entity, ValidationResult validation)
        {
            Entity = entity;
            Validation = validation;
        }

        public readonly T Entity { get; }
        public readonly ValidationResult Validation { get; }
    }
}
