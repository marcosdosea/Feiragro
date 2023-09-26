using Core;
using System.ComponentModel.DataAnnotations;

namespace FeiragroWeb.Models
{
    public class ProdutoFeiraModel
    {

        public int IdProduto { get; set; }

        public int IdFeira { get; set; }

        [Display(Name = "Quantidade de Produtos Disponiveis")]
        [Required(ErrorMessage = "Quantidade de Produtos Necessária")]
        public int QuantidadeDisponivel { get; set; }

        [Display(Name = "Quantidade de Produtos Vendidos")]
        public int QuantidadeVendida { get; set; }

        [Display(Name = "Quantidade de Produtos Ajustados")]
        public int QuantidadeAjuste { get; set; }

        [Display(Name = "Unidade de Medida do Produto")]
        [Required(ErrorMessage = "Unidade de Medida Necessária")]
        public string UnidadeMedida { get; set; } = null!;

        [Display(Name = "Valor do Produto")]
        [Required(ErrorMessage = "O valor é necessário")]
        public decimal Valor { get; set; }

        [Display(Name = "Justificativa da Reserva")]
        [StringLength(20, ErrorMessage = "A justificativa precisa ter no até 20 caracteres")]
        public string? JustificativaReserva { get; set; }

        public virtual Feira IdFeiraNavigation { get; set; } = null!;

        public virtual Produto IdProdutoNavigation { get; set; } = null!;

        public virtual ICollection<Produtovendum> Produtovenda { get; set; } = new List<Produtovendum>();

        public virtual ICollection<Reservaprodutofeira> Reservaprodutofeiras { get; set; } = new List<Reservaprodutofeira>();
    }

}