using Core;
using Core.Service;

namespace Service
{
    public class ReservaProdutoFeiraService : IReservaProdutoFeiraService
    {
        private readonly FeiragroContext context;


        public ReservaProdutoFeiraService(FeiragroContext context)
        {
            this.context = context;
        }

        public int Create(Reservaprodutofeira reservaprodutofeira)
        {
            context.Add(reservaprodutofeira);
            context.SaveChanges();
            return reservaprodutofeira.IdFeira;
        }

        public bool Delete(Reservaprodutofeira reservaprodutofeira)
        {
            context.Remove(reservaprodutofeira);
            context.SaveChanges();
            return true;
        }

        public int Edit(Reservaprodutofeira reservaprodutofeira)
        {
            context.Update(reservaprodutofeira);
            context.SaveChanges();
            return reservaprodutofeira.IdFeira;
        }

        public int Get(Reservaprodutofeira reservaprodutofeira)
        {
            return context.Reservaprodutofeiras.Find(reservaprodutofeira.IdFeira);
        }

        public IEnumerable<Reservaprodutofeira> GetAll()
        {
            return context.Reservaprodutofeiras.AsNoTracking();
        }

        public IEnumerable<Reservaprodutofeira> GetByIdFeira(int idFeira)
        {
            var query = from reservaProdutoFeira in context.Reservaprodutofeiras
                        where reservaProdutoFeira.IdFeira == idFeira
                        orderby reservaProdutoFeira.IdFeira
                        select reservaProdutoFeira;
            return query;
        }
    }
}