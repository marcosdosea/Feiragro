using Core;
using Core.Service;

namespace Service
{
    public class TipoProdutoService : ITipoProdutoService
    {
        private readonly FeiragroContext context;


        public TipoProdutoService(FeiragroContext context)
        {
            this.context = context;
        }
        public int Create(Tipoproduto tipoProduto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Tipoproduto tipoProduto)
        {
            throw new NotImplementedException();
        }

        public int Edit(Tipoproduto tipoProduto)
        {
            throw new NotImplementedException();
        }

        public int Get(Tipoproduto tipoProduto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tipoproduto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tipoproduto> GetByNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
