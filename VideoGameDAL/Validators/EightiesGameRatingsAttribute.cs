using AboutMeProject.Models;
using System.ComponentModel.DataAnnotations;

namespace AboutMeProject.Validators
{
    //custom validation across fields or models
    //must end with attribute
    public class EightiesGameRatingsAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var game = (VideoGame)validationContext.ObjectInstance;
            if(game.Year >= 1980 && game.Year <= 1990 ) //game.Rating == "Mature")
            {
                return new ValidationResult("games can't be bad in the 80's");
            }
            return ValidationResult.Success;
        }
    }
}
