using System.ComponentModel.DataAnnotations;

namespace QuarterlySales.Models.Validation
{
    public class GreaterThanAttribute : ValidationAttribute
    {
        private object compareValue;

        public GreaterThanAttribute(object val)
        {
            compareValue = val;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext ctx)
        {
            if(value is int)
            {
                int intToCheck = (int)value;
                int intToCompare = (int)compareValue;

                if(intToCheck > intToCompare)
                {
                    return ValidationResult.Success!;
                }
            }
            else if(value is double)
            {
                double doubleToCheck = (double)value;
                double doubleToCompare = (double)compareValue;

                if(doubleToCheck > doubleToCompare)
                {
                    return ValidationResult.Success!;
                }
            }
            return base.IsValid(value, ctx);
        }

    }
}
