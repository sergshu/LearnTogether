using System.ComponentModel.DataAnnotations;

namespace WebAppAutorization.Models.Validators
{
    public class FirstCapitalAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null || value.ToString().Length < 2)
            {
                return false;
            }

            var firstChar = (value as string).Substring(0,1);

            if(firstChar.ToUpper() == firstChar)
            {
                var str = (value as string);
                var rest = str.Substring(1, str.Length - 1);
                return rest.ToLower() == rest;
            }

            return false;
        }
    }
}
