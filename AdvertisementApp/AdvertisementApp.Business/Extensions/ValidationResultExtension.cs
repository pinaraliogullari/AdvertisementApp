using AdvertisementApp.Shared;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtension
    {

        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new()
                {
                    ErrorMessage=error.ErrorMessage,
                    PropertyName=error.PropertyName,
                });
            }
            return errors;
        }
    }
}
