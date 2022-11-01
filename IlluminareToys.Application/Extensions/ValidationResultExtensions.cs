using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IlluminareToys.Application.Extensions
{
    public static class ValidationResultExtensions
    {
        public static void AddToModelState(this IEnumerable<ValidationFailure> errors, ModelStateDictionary modelState)
        {
            foreach (var error in errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
