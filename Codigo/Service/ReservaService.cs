using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ReservaService : IReservaService
    {
        private readonly FeiragroContext context;

        public ReservaService(FeiragroContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Funcao para criar uma ReservaService
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns>id da reserva</returns>
        public int Create(Reserva reserva)
        {
            context.Add(reserva);
            context.SaveChanges();
            return reserva.Id;
        }

        public void Edit(Reserva reserva)
        {
            context.Update(reserva);
            context.SaveChanges();
        }

        public void Delete(int reserva)
        {
            var associacao = context.Associacaos.Find(reserva);
            context.Remove(reserva!);
            context.SaveChanges();
        }

        public Reserva Get(Reserva idReserva)
        {
            return context.Reservas.Find(idReserva)!;
        }

        public IEnumerable<Reserva> GetAll()
        {
            return context.Reservas.AsNoTracking();
        }
    }
}
