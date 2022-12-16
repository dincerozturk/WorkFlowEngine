using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
//using System.Web.Mvc;

namespace WorkFlowManager.Helper
{
    public interface IValidationHelper
    {
        bool Validate<TModel, TValidator>(TModel model, TValidator validator,
            ModelStateDictionary modelState)
            where TValidator : AbstractValidator<TModel>;
    }
}
