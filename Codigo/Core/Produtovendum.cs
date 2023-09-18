namespace Core;

public partial class Produtovendum
{
    public int IdFeira { get; set; }

    public int IdProduto { get; set; }

    public int IdVenda { get; set; }

    public decimal Quantidade { get; set; }

    public virtual Produtofeira Id { get; set; } = null!;

    public virtual Vendum IdVendaNavigation { get; set; } = null!;
}
