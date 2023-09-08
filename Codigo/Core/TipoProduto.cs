using System;
using System.Collections.Generic;

namespace Core;

public partial class Tipoproduto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
