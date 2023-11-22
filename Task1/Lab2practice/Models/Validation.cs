using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2practice.Models
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string password)
            {
               
                if (password.Length < 8)
                {
                    return false;
                }

               
                if (password.Count(char.IsLetter) < 2)
                {
                    return false;
                }

               
                if (!password.Any(char.IsDigit))
                {
                    return false;
                }

                
                if (password.Count(char.IsPunctuation) < 2)
                {
                    return false;
                }

                
                if (password.Contains(' '))
                {
                    return false;
                }

                return true;
            }

            
            return false;
        }
    }

    public class AgeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateOfBirth)
            {
                
                int age = DateTime.Today.Year - dateOfBirth.Year;

               
                if (dateOfBirth.Date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }

               
                return age > 18;
            }

           
            return false;
        }
    }

    public class NoSpaceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is string username)
            {
                if (username.Contains(" "))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }

}