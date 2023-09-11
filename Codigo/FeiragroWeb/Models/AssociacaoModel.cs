using System.ComponentModel.DataAnnotations;

namespace FeiragroWeb.Models
{
    public class AssociacaoModel
    {
        [Display(Name = "Id Associacao")]
        [Required (ErrorMessage = "Campo obrigatório")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength (50,MinimumLength = 3, ErrorMessage = "Precisa ter entre 3 a 50 dígitos")]
        public string Endereco { get; set; } = null!;


        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Precisa ter 15 dígitos")]
        public string Cnpj { get; set; } = null!;


        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(14, MinimumLength = 13, ErrorMessage = "Precisa ter entre 13 a 14 dígitos")]
        public string Telefone { get; set; } = null!;


        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime Data { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w+$", ErrorMessage = "Por favor, insira um endereço de e-mail válido")]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome do Usuário  deve ter entre 3 e 50 dígitos")]
        public string Nome { get; set; } = null!;


        public string Status { get; set; } = "ATIVO";
    }
}
