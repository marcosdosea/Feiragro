using Core;
using Core.Service;

namespace Service
{
    public class ProdutoVendumService : IProdutoVendumService
    {
        private readonly FeiragroContext context;


        public ProdutoVendumService(FeiragroContext context)
        {
            this.context = context;
        }

        public int Create(Produtovendum produto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Produtovendum produto)
        {
            throw new NotImplementedException();
        }

        public int Edit(Produtovendum produto)
        {
            throw new NotImplementedException();
        }

        public int Get(Produtovendum produto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produtovendum> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produtovendum> GetByNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
