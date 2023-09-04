using Core;
using Core.Service;

namespace Service
{
    public class ProdutoFeiraService : IProdutoFeiraService
    {
        private readonly FeiragroContext context;


        public ProdutoFeiraService(FeiragroContext context)
        {
            this.context = context;
        }

        public int Create(Produtofeira produtofeira)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Produtofeira produtofeira)
        {
            throw new NotImplementedException();
        }

        public int Edit(Produtofeira produtofeira)
        {
            throw new NotImplementedException();
        }

        public int Get(Produtofeira produtofeira)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produtofeira> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produtofeira> GetByNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
