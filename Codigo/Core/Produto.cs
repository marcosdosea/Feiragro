namespace Core;

public partial class Produto
{
    public int Id { get; set; }

    public int IdTipoProduto { get; set; }

    public string Nome { get; set; } = null!;

    public byte[] Imagem { get; set; } = null!;

    public virtual Tipoproduto IdTipoProdutoNavigation { get; set; } = null!;

    public virtual ICollection<Produtofeira> Produtofeiras { get; set; } = new List<Produtofeira>();
}
