using System.ComponentModel.DataAnnotations;

namespace FeiragroAPI.Models
{
    public class AssociacaoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O Nome da associação deve ter entre 2 e 50 dígitos")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Campo obrigatorio")]
        [RegularExpression(@"^[0-9]{14}$", ErrorMessage = "O Cnpj Precisa ter 14 dígitos")]
        [StringLength(14)]
        public string Cnpj { get; set; } = null!;

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50)]
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w{1,50}$", ErrorMessage = "Por favor, insira um endereço de e-mail válido com no máximo 50 caracteres.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(8)]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP deve conter exatamente 8 dígitos.")]
        public string Cep { get; set; } = null!;

        [Display(Name = "UF")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(2,MinimumLength =2,ErrorMessage ="UF Precisa ter 2 caracteres")]
        public string Uf { get; set; } = null!;

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "O município Precisa ter entre 1 a 20 caracteres")]
        public string Municipio { get; set; } = null!;

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "A rua Precisa ter entre 1 a 50 caracteres")]
        public string Rua { get; set; } = null!;

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O bairro Precisa ter entre 1 a 50 caracteres")]
        public string Bairro { get; set; } = null!;

        [StringLength(12)]
        [RegularExpression(@"^[0-9]{0,10}", ErrorMessage = "O número precisa ter até no máximo 10 dígitos.")]
        public string? Numero { get; set; } = null!;

        [StringLength(80, MinimumLength = 0, ErrorMessage = "O complemento Precisa ter entre 0 a 80 caracteres")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(14, MinimumLength = 13, ErrorMessage = "Precisa ter entre 13 a 14 dígitos")]
        public string Telefone { get; set; } = null!;

        public string? Status { get; set; }

        public DateTime? Data { get; set; }
    }
}