using System;
using System.Collections.Generic;

namespace Core;

public partial class Associacao
{
    public int Id { get; set; }

    public string Endereco { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public DateTime Data { get; set; }

    public string Email { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<Feira> Feiras { get; set; } = new List<Feira>();

    public virtual ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();

    public virtual ICollection<Pontoassociacao> Pontoassociacaos { get; set; } = new List<Pontoassociacao>();
}
