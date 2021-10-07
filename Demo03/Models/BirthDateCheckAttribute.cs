using System;
using System.ComponentModel.DataAnnotations;

namespace Demo03.Models
{
    public class BirthDateCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var dob = (DateTime)value;
                if (dob > DateTime.Now)
                {
                    return new ValidationResult("Không thể sinh ở tương lai");
                }
                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult("Ngày sinh không hợp lệ");
            }
        }
    }
}