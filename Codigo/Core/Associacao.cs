namespace Core;

public partial class Associacao
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string Uf { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string? Complemento { get; set; }

    public string Telefone { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime Data { get; set; }

    public virtual ICollection<Feira> Feiras { get; set; } = new List<Feira>();

    public virtual ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();

    public virtual ICollection<Pontoassociacao> Pontoassociacaos { get; set; } = new List<Pontoassociacao>();
}
