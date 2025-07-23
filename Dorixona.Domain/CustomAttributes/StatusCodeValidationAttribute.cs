using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.CustomAttributes;
public class StatusCodeValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is int statusCode)
        {
            if (statusCode >= 1 && statusCode <= 5)
            {
                return ValidationResult.Success;
            }
        }

        return new ValidationResult("statusCode must be between 1 and 5");
    }
}
