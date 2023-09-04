using System;
using System.Collections.Generic;

namespace Core;

public partial class Feira
{
    public int Id { get; set; }

    public int IdPontoAssociacao { get; set; }

    public int IdAssociacao { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public string Status { get; set; } = null!;

    public virtual Associacao IdAssociacaoNavigation { get; set; } = null!;

    public virtual Pontoassociacao IdPontoAssociacaoNavigation { get; set; } = null!;

    public virtual ICollection<Produtofeira> Produtofeiras { get; set; } = new List<Produtofeira>();
}
