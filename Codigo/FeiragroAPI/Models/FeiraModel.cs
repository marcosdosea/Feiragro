using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FeiragroAPI.Models
{
    public class FeiraModel
    {
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
    }
}
