using QLNS.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace QLNS.Helpers.CustomValidationAttribute
{
    public class EmailUniqueAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var _context = (DBContext)validationContext.GetService(typeof(DBContext));
                var entity = _context.Employees.Where(x => x.Email.Equals(value)).FirstOrDefault();

                if (entity != null)
                {
                    return new ValidationResult(GetErrorMessage(value.ToString()));
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage(string email)
        {
            return $"Email {email} is alrealy in use";
        }
    }
}
