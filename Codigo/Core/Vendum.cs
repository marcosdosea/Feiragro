namespace Core;

public partial class Vendum
{
    public int Id { get; set; }

    public DateTime Data { get; set; }

    public int IdCliente { get; set; }

    public int IdProdutor { get; set; }

    public virtual Pessoa IdClienteNavigation { get; set; } = null!;

    public virtual Pessoa IdProdutorNavigation { get; set; } = null!;

    public virtual ICollection<Produtovendum> Produtovenda { get; set; } = new List<Produtovendum>();
}
