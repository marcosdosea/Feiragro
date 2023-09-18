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
        /// Funcao para criar uma Reserva
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns>id da reserva</returns>
        public int Create(Reserva reserva)
        {
            context.Add(reserva);
            context.SaveChanges();
            return reserva.Id;
        }

        /// <summary>
        /// Funcao para Editar uma Reserva
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns></returns>
        public void Edit(Reserva reserva)
        {
            context.Update(reserva);
            context.SaveChanges();
        }

        /// <summary>
        /// Funcao para Deletar uma Reserva
        /// </summary>
        /// <param name="idReserva"></param>
        /// <returns></returns>
        public void Delete(int idReserva)
        {
            var associacao = context.Associacaos.Find(idReserva);
            context.Remove(idReserva!);
            context.SaveChanges();
        }


        /// <summary>
        /// Funcao para Pesquisar uma Reserva
        /// </summary>
        /// <param name="idReserva"></param>
        /// <returns>A Reserva</returns>
        public Reserva Get(Reserva idReserva)
        {
            return context.Reservas.Find(idReserva)!;
        }

        /// <summary>
        /// Funcao para Pesquisar todas as Reserva
        /// </summary>
        /// <returns>Lista com todas as reservas</returns>
        public IEnumerable<Reserva> GetAll()
        {
            return context.Reservas.AsNoTracking();
        }
    }
}
