namespace Core;

public partial class Reservaprodutofeira
{
    public int IdReserva { get; set; }

    public int IdFeira { get; set; }

    public int IdProduto { get; set; }

    public decimal Quantidade { get; set; }

    public virtual Produtofeira Id { get; set; } = null!;

    public virtual Reserva IdReservaNavigation { get; set; } = null!;
}
