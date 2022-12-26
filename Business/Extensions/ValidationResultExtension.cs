using System.Collections.Generic;
using Common;
using FluentValidation.Results;

namespace Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this FluentValidation.Results.ValidationResult validationResult)
        {
             List<CustomValidationError> errors = new();
            foreach (var item in validationResult.Errors)
            {
               errors.Add(new(){
                    ErrorMessage=item.ErrorMessage,
                    PropertyName =item.PropertyName
               });
               
            }
            return errors;
        }
    }
}