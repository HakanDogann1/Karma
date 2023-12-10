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
    }
}
