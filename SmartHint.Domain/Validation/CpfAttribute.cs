using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartHint.Domain.Validation
{
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var cpf = value.ToString().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !Regex.IsMatch(cpf, @"^\d{11}$"))
            {
                return new ValidationResult("CPF inválido.");
            }

            var invalidCpfs = new string[]
            {
            "00000000000",
            "11111111111",
            "22222222222",
            "33333333333",
            "44444444444",
            "55555555555",
            "66666666666",
            "77777777777",
            "88888888888",
            "99999999999"
            };

            if (Array.Exists(invalidCpfs, element => element == cpf))
            {
                return new ValidationResult("CPF inválido.");
            }

            var sum = 0;
            for (var i = 0; i < 9; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (10 - i);
            }

            var remainder = sum % 11;
            var firstDigit = remainder < 2 ? 0 : 11 - remainder;

            if (int.Parse(cpf[9].ToString()) != firstDigit)
            {
                return new ValidationResult("CPF inválido.");
            }

            sum = 0;
            for (var i = 0; i < 10; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (11 - i);
            }

            remainder = sum % 11;
            var secondDigit = remainder < 2 ? 0 : 11 - remainder;

            if (int.Parse(cpf[10].ToString()) != secondDigit)
            {
                return new ValidationResult("CPF inválido.");
            }

            return ValidationResult.Success;
        }
    }
}
