using System.ComponentModel.DataAnnotations;

namespace FeiragroWeb.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome do Usuário  deve ter entre 3 e 50 dígitos")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O número do seu cpf deve conter 11 dígitos")]
        public string Cpf { get; set; } = null!;

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(14, MinimumLength = 13, ErrorMessage = "O número de telefone deve conter entre 13 ou 14 dígitos")]
        public string Telefone { get; set; } = null!;

        public string TipoPessoa { get; set; } ="c";

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w+$", ErrorMessage = "Por favor, insira um endereço de e-mail válido")]
        public string Email { get; set; } = null!;

        public int? IdAssociacao { get; set; }
    }
}
