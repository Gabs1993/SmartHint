using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace SmartHint.Domain.Validation
{
    public class CpfCnpjAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var input = value.ToString().Replace(".", "").Replace("-", "").Replace("/", "");

            if (input.Length == 11)
            {
                return ValidateCpf(input);
            }
            else if (input.Length == 14)
            {
                return ValidateCnpj(input);
            }

            return new ValidationResult("CPF ou CNPJ inválido.");
        }

        private ValidationResult ValidateCpf(string cpf)
        {
            if (!Regex.IsMatch(cpf, @"^\d{11}$"))
            {
                return new ValidationResult("CPF inválido.");
            }

            var invalidCpfs = new string[]
            {
                "00000000000", "11111111111", "22222222222", "33333333333", "44444444444",
                "55555555555", "66666666666", "77777777777", "88888888888", "99999999999"
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

        private ValidationResult ValidateCnpj(string cnpj)
        {
            if (!Regex.IsMatch(cnpj, @"^\d{14}$"))
            {
                return new ValidationResult("CNPJ inválido.");
            }

            var invalidCnpjs = new string[]
            {
                "00000000000000", "11111111111111", "22222222222222", "33333333333333", "44444444444444",
                "55555555555555", "66666666666666", "77777777777777", "88888888888888", "99999999999999"
            };

            if (Array.Exists(invalidCnpjs, element => element == cnpj))
            {
                return new ValidationResult("CNPJ inválido.");
            }

            var sum = 0;
            var weight = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (var i = 0; i < 12; i++)
            {
                sum += int.Parse(cnpj[i].ToString()) * weight[i];
            }

            var remainder = sum % 11;
            var firstDigit = remainder < 2 ? 0 : 11 - remainder;

            if (int.Parse(cnpj[12].ToString()) != firstDigit)
            {
                return new ValidationResult("CNPJ inválido.");
            }

            sum = 0;
            weight = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (var i = 0; i < 13; i++)
            {
                sum += int.Parse(cnpj[i].ToString()) * weight[i];
            }

            remainder = sum % 11;
            var secondDigit = remainder < 2 ? 0 : 11 - remainder;

            if (int.Parse(cnpj[13].ToString()) != secondDigit)
            {
                return new ValidationResult("CNPJ inválido.");
            }

            return ValidationResult.Success;
        }
    }
}
