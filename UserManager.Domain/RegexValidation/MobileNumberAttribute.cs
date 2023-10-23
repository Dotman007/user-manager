using System.ComponentModel.DataAnnotations;
namespace UserManager.Domain.RegexValidation
{
    public class MobileNumberAttribute : ValidationAttribute
    {
        private const string RegexPattern = @"^\+234\d{10}$"; // Regex pattern for Nigerian phone numbers with the country code

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var phoneNumber = value.ToString();
                if (System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, RegexPattern))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("The phone number should be in the format +234XXXXXXXXXX");
                }
            }

            return ValidationResult.Success; // Returning success if the value is null
        }
    }
}
