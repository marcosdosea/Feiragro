using Core;
using Core.Service;

namespace Service
{
    public class ReservaService : IReservaService
    {
        private readonly FeiragroContext context;


        public ReservaService(FeiragroContext context)
        {
            this.context = context;
        }

        public int Create(Reserva reserva)
        {
            context.Add(reserva);
            context.SaveChanges();
            return reserva.Id;
        }

        public int Edit(Reserva reserva)
        {
            context.Update(reserva);
            context.SaveChanges();
            return reserva.Id;
        }

        public bool Delete(Reserva reserva)
        {
            context.Update(reserva);
            context.SaveChanges();
            return true;
        }

        public int Get(Reserva reserva)
        {
            return context.Reservas.Find(reserva.Id);
        }

        public IEnumerable<Reserva> GetAll()
        {
            return context.Reservas.AsNoTracking();
        }

        public IEnumerable<Reserva> GetByIdPessoa(int idPessoa)
        {
            var query = from reserva in context.Reservas
                        where reserva.IdPessoa == idPessoa
                        select reserva;
            return query;
        }
    }
}