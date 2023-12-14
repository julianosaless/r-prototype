using Microsoft.AspNetCore.Mvc;

using Ria.Common.Validations;

namespace Ria.Api.Infrastructure
{
    public class ApiControllerBase : ControllerBase
    {
        protected OkObjectResult StandardOk(object value)
        {
            return Ok(value);
        }

        protected BadRequestObjectResult StandardBadRequest(ValidationResult validationResult)
        {
            ValidationResultToModelState(validationResult);
            return BadRequest(validationResult);
        }

        private void ValidationResultToModelState(ValidationResult result)
        {
            if (result == null || result.IsValid)
                return;

            var properties = result.Errors
                .GroupBy(property => property.PropertyName);
            foreach (var property in properties)
            {
                var errors = result.Errors
                    .Where(error => error.PropertyName == property.Key)
                    .Select(error => error.ErrorMessage)
                    .ToList();

                errors.ForEach(error =>
                {
                    ModelState.AddModelError(property.Key, error);
                });
            }
        }
    }
}
