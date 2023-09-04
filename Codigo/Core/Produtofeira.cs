using System;
using System.Collections.Generic;

namespace Core;

public partial class Produtofeira
{
    public int IdProduto { get; set; }

    public int IdFeira { get; set; }

    public int QuantidadeDisponivel { get; set; }

    public int QuantidadeVendida { get; set; }

    public int QuantidadeAjuste { get; set; }

    public string UnidadeMedida { get; set; } = null!;

    public decimal Valor { get; set; }

    public string? JustificativaReserva { get; set; }

    public virtual Feira IdFeiraNavigation { get; set; } = null!;

    public virtual Produto IdProdutoNavigation { get; set; } = null!;

    public virtual ICollection<Produtovendum> Produtovenda { get; set; } = new List<Produtovendum>();

    public virtual ICollection<Reservaprodutofeira> Reservaprodutofeiras { get; set; } = new List<Reservaprodutofeira>();
}
