using Core;
using Core.Service;

namespace Service
{
    public class TipoProdutoService : ITipoProdutoService
    {
        private readonly FeiragroContext context;
        public TipoProdutoService (FeiragroContext context)
        {
            this.context = context;
        }


        public bool Create(Tipoproduto tipoProduto)
        {
            context.Add(tipoproduto);
            context.SaveChanges();
            return true;
        }

        public bool Delete(Tipoproduto tipoProduto)
        {
            throw new NotImplementedException();
        }

        public Tipoproduto? Edit(Tipoproduto tipoProduto)
        {
            throw new NotImplementedException();
        }

        public Tipoproduto Get(int tipoProduto)
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
