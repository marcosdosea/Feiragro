using System;
using System.Collections.Generic;

namespace Core;

public partial class Reserva
{
    public int Id { get; set; }

    public int IdPessoa { get; set; }

    public DateTime Data { get; set; }

    public string Status { get; set; } = null!;

    public virtual Pessoa IdPessoaNavigation { get; set; } = null!;

    public virtual ICollection<Reservaprodutofeira> Reservaprodutofeiras { get; set; } = new List<Reservaprodutofeira>();
}
