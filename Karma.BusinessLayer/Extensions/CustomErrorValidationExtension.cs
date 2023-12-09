using FluentValidation.Results;
using Karma.CommonLayer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Extensions
{
    public static class CustomErrorValidationExtension
    {
        public static List<CustomError> CustomValidationError(this ValidationResult validationResult)
        {
            var customErrors = new List<CustomError>();

            foreach (var item in validationResult.Errors)
            {
                customErrors.Add(new CustomError { PropertyName = item.PropertyName, Description = item.ErrorMessage });
            }
            return customErrors;
        }
    }
}
