namespace Core;

public partial class Pessoa
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public string Telefone { get; set; } = null!;

    public string TipoPessoa { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? IdAssociacao { get; set; }

    public virtual Associacao? IdAssociacaoNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Vendum> VendumIdClienteNavigations { get; set; } = new List<Vendum>();

    public virtual ICollection<Vendum> VendumIdProdutorNavigations { get; set; } = new List<Vendum>();
}
