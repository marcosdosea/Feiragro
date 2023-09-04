namespace Core.Service
{
    public interface IReservaService
    {
        public int Get(Reserva reserva);
        public int Create(Reserva reserva);
        public int Edit(Reserva reserva);
        IEnumerable<Reserva> GetAll();
        IEnumerable<Reserva> GetByIdFeira(int id);
    }
}
