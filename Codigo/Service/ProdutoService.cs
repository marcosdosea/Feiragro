using Core;
using Core.Service;

namespace Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly FeiragroContext context;


        public ProdutoService(FeiragroContext context)
        {
            this.context = context;
        }

        public int Create(Produto produto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Produto produto)
        {
            throw new NotImplementedException();
        }

        public int Edit(Produto produto)
        {
            throw new NotImplementedException();
        }

        public int Get(Produto produto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetByNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
