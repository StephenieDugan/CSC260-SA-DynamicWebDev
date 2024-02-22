using ValidationPractice.Models;
using System.ComponentModel.DataAnnotations;

namespace ValidationPractice.Validators
{
    public class ProfileAddressAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var profile = (ProfileModel)validationContext.ObjectInstance;

            if (profile.IsAddressEmpty || (!string.IsNullOrWhiteSpace(profile.Street)
                && !string.IsNullOrWhiteSpace(profile.City) && !string.IsNullOrWhiteSpace(profile.State)
                && !string.IsNullOrWhiteSpace(profile.ZipCode)))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Address should be completely filled out.");
        }
    }
}
