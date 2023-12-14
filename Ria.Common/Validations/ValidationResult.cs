
using System.Net;

namespace Ria.Common.Validations
{
    public class ValidationResult
    {
        public bool IsValid => !Errors.Any();

        public bool HasStatusBadRaquestStatus => Errors.Any(error => error.HasBadRequestStatus());
        public bool HasNotFoundStatus => Errors.Any(error => error.HasNotFoundStatus());

        public IList<ValidationFailure> Errors { get; } = new List<ValidationFailure>();

        public ValidationResult()
        {
        }

        public ValidationResult(string error)
        {
            Errors.Add(new ValidationFailure(null, error));
        }

        public ValidationResult(string propertyName, string errorMessage, HttpStatusCode httpStatusCode)
        {
            Errors.Add(new ValidationFailure(propertyName, errorMessage, httpStatusCode));
        }

        public static ValidationResult Success => new ValidationResult();

        public static implicit operator ValidationResult(string error)
        {
            return new ValidationResult(error);
        }
    }

    public readonly struct ValidationFailure
    {
        public ValidationFailure(string propertyName, string errorMessage, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            HttpStatusCode = httpStatusCode;
        }

        public string PropertyName { get; }
        public string ErrorMessage { get; }
        public HttpStatusCode HttpStatusCode { get; }

        public bool HasBadRequestStatus() => HttpStatusCode == HttpStatusCode.BadRequest;
        public bool HasNotFoundStatus() => HttpStatusCode == HttpStatusCode.NotFound;
    }
}
