namespace Core;

public partial class Pontoassociacao
{
    public int Id { get; set; }

    public int IdAssociacao { get; set; }

    public string Cep { get; set; } = null!;

    public string Uf { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public int Numero { get; set; }

    public string? Complemento { get; set; }

    public virtual ICollection<Feira> Feiras { get; set; } = new List<Feira>();

    public virtual Associacao IdAssociacaoNavigation { get; set; } = null!;
}
