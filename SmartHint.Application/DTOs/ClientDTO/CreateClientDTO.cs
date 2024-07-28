using SmartHint.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHint.Application.DTOs.ClientDTO
{
    public class CreateClientDTO
    {
        [Required, StringLength(150)]
        public string? NomeRazaoSocial { get; set; }
        [Required, StringLength(150)]
        [EmailAddress(ErrorMessage = "O Email não é válido.")]
        public string? Email { get; set; }
        [Required]
        public string? Telefone { get; set; }
        [Required]
        public string? TipoPessoa { get; set; }
        [Required]
        [Cpf(ErrorMessage = "CPF inválido.")]
        public string? CpfCnpj { get; set; }
        [Required]
        public string? InscricaoEstadual { get; set; }

        //Pessoa Fisica
        public string? Genero { get; set; }

        public DateTime? DateNascimento { get; set; }

        public bool? Bloqueado { get; set; }

        [StringLength(15, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 15 caracteres.")]
        [RegularExpression(@"^.{8,15}$", ErrorMessage = "A senha deve ter entre 8 e 15 caracteres.")]
        public string? Senha { get; set; }


        [StringLength(15, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 15 caracteres.")]
        [RegularExpression(@"^.{8,15}$", ErrorMessage = "A senha deve ter entre 8 e 15 caracteres.")]
        public string ConfirmarSenha { get; set; }
    }
}
