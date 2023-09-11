namespace Core.Service
{
    public interface IReservaService
    {
        public Reserva Get(Reserva reserva);
        public int Create(Reserva reserva);
        public void Edit(Reserva reserva);
        IEnumerable<Reserva> GetAll();
    }
}
