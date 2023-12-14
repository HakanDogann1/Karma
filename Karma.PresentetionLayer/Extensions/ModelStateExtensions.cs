using Karma.PresentetionLayer.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Karma.PresentetionLayer.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddModelErrorList(this ModelStateDictionary modelState,List<string> errors)
        {
            errors = new List<string>();

            errors.ForEach(error =>
            {
                modelState.AddModelError(string.Empty, error);
            });
        }

        public static void AddModelErrorList(this ModelStateDictionary modelState,List<CustomError> customErrors)
        {
            var errors = new List<CustomError>();

            foreach (var error in customErrors)
            {
                modelState.AddModelError(error.PropertyName, error.Description);
            }
        }
    }
}
