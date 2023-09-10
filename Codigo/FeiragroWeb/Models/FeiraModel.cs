using Core;
using System.ComponentModel.DataAnnotations;

namespace FeiragroWeb.Models
{
    public class FeiraModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int Id { get; set; }

        [Display(Name = "Id do PontoAssociacao")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int IdPontoAssociacao { get; set; }

        [Display(Name = "Id do Associacao")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int IdAssociacao { get; set; }

        [Display(Name = "Data de inicio")]
        [Required(ErrorMessage = "A data de inicio é obrigatória")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data de Fim")]
        public DateTime? DataFim { get; set; }

        [Display(Name = "Status atual da feira")]
        public string? Status { get; set; } = "ABERTO";

        [Display(Name = "Associação em que a feira está atribuida")]
        [Required(ErrorMessage = "A feira precisa estar atribuida a uma associação")]
        public virtual Associacao IdAssociacaoNavigation { get; set; } = null!;

        [Display(Name = "Ponto de venda da feira")]
        [Required(ErrorMessage = "A feira precisa ter um ponto de venda")]
        public virtual Pontoassociacao IdPontoAssociacaoNavigation { get; set; } = null!;

        [Display(Name = "Produtos disponibilizados")]
        public virtual ICollection<Produtofeira> Produtofeiras { get; set; } = new List<Produtofeira>();
    }
}
