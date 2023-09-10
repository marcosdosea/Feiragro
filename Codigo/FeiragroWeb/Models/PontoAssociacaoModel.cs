using Core;
using System.ComponentModel.DataAnnotations;

namespace FeiragroWeb.Models
{
    public class PontoAssociacaoModel
    {
        [Display (Name = "Código")]
        [Required(ErrorMessage = "Código de associacao é obrigatório")]
        public int Id { get; set; }
        [Display(Name = "Id do PontoAssociacao")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int IdAssociacao { get; set; }

        public string Cep { get; set; } = null!;

        public string Complemento { get; set; } = null!;

        public string Uf { get; set; } = null!;

        public string Municipio { get; set; } = null!;

        public string Rua { get; set; } = null!;

        public int Numero { get; set; }

        public string Bairro { get; set; } = null!;

        public virtual ICollection<Feira> Feiras { get; set; } = new List<Feira>();

        public virtual Associacao IdAssociacaoNavigation { get; set; } = null!;
    }

}

