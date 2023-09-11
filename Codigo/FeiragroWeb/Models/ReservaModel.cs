using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Core;

namespace FeiragroWeb.Models
{
    public class ReservaModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int Id { get; set; }

        [Display(Name = "Id da Pessoa")]
        [Required(ErrorMessage = "O IdPessoa é obrigatório")]
        public int IdPessoa { get; set; }

        [Display(Name = "Data da Reserva")]
        [Required(ErrorMessage = "A data é obrigatório")]
        public DateTime Data { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "O Status é obrigatório")]
        public string Status { get; set; } = null!;

        public virtual Pessoa IdPessoaNavigation { get; set; } = null!;

        public virtual ICollection<Reservaprodutofeira> Reservaprodutofeiras { get; set; } = new List<Reservaprodutofeira>();
    }
}