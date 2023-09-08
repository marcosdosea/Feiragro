using System.ComponentModel.DataAnnotations;

namespace FeiragroWeb.Models
{
    public class TipoProdutoModel
    {
        [Display(Name ="Id")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "Nome do Tipo do Produto deve ter entre 3 e 50 dígitos")]
        public string Nome { get; set; } = null!;
    }
}
