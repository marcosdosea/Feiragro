using Core;
using System.ComponentModel.DataAnnotations;

namespace FeiragroWeb.Models
{
    public class PontoAssociacaoModel
    {
        public int Id { get; set; }

        [Display(Name = "Id da Associação")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int IdAssociacao { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP precisa ter 8 caracteres")]
        public string Cep { get; set; } = null!;

        [StringLength(80, MinimumLength = 3, ErrorMessage = "O complemento precisa estar entre 3 e 80 caracteres")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "UF é obrigatório")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O complemento precisa ter 2 caracteres")]
        public string Uf { get; set; } = null!;

        [Required(ErrorMessage = "O Municipio é obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O complemento precisa estar entre 3 e 20 caracteres")]
        public string Municipio { get; set; } = null!;

        [Required(ErrorMessage = "A rua é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O complemento precisa estar entre 3 e 50 caracteres")]
        public string Rua { get; set; } = null!;

        [Display(Name = "Número do endereço PontoAssociacao")]
        [Required(ErrorMessage = "O Número é obrigatório")]
        public int Numero { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "O Bairro é obrigatório")]
        public string Bairro { get; set; } = null!;

    }

}

