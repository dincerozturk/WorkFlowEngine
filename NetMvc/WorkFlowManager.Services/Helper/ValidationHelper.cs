using FluentValidation;
using FluentValidation.Results;
using System.Web.Mvc;

namespace WorkFlowManager.Helper
{
    public class ValidationHelper : IValidationHelper
    {
        public bool Validate<TModel, TValidator>(TModel model, TValidator validator,
            ModelStateDictionary modelState)
            where TValidator : AbstractValidator<TModel>
        {
            ValidationResult result = validator.Validate(model);

            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return result.IsValid;
        }
    }
}
