using ValidationPractice.Models;
using System.ComponentModel.DataAnnotations;

namespace ValidationPractice.Validators
{
    public class ProfileAddressAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var game = (ProfileModel)validationContext.ObjectInstance;
            if ()
            {
                return new ValidationResult("games can't be bad in the 80's");
            }
            return ValidationResult.Success;
        }
    }
}
