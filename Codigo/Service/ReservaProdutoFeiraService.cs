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
            throw new NotImplementedException();
        }

        public bool Delete(Reservaprodutofeira reservaprodutofeira)
        {
            throw new NotImplementedException();
        }

        public int Edit(Reservaprodutofeira reservaprodutofeira)
        {
            throw new NotImplementedException();
        }

        public int Get(Reservaprodutofeira reservaprodutofeira)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservaprodutofeira> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservaprodutofeira> GetByNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
