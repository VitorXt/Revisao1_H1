using Revisao1.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Revisao1.Models.Request
{
    public class RegistroJogoViewModel
    {
        [Required(ErrorMessage = "O Nome é obrigatória.")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [CpfValidation(ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório.")]
        [Range(1, 60, ErrorMessage = "O Número deve ser entre 1 e 60.")]
        public int Numero1 { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório.")]
        [Range(1, 60, ErrorMessage = "O Número deve ser entre 1 e 60.")]
        public int Numero2 { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório.")]
        [Range(1, 60, ErrorMessage = "O Número deve ser entre 1 e 60.")]
        public int Numero3 { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório.")]
        [Range(1, 60, ErrorMessage = "O Número deve ser entre 1 e 60.")]
        public int Numero4 { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório.")]
        [Range(1, 60, ErrorMessage = "O Número deve ser entre 1 e 60.")]
        public int Numero5 { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório.")]
        [Range(1, 60, ErrorMessage = "O Número deve ser entre 1 e 60.")]
        public int Numero6 { get; set; }

        [JsonIgnore]
        public DateTime DataJogo { get; set; }
    }
}
