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
            context.Add(tipoProduto);
            context.SaveChanges();
            return tipoProduto.Id;
        }

        public bool Delete(Tipoproduto tipoProduto)
        {
            context.Remove(tipoProduto);
            context.SaveChanges();
            return true;
        }

        public int Edit(Tipoproduto tipoProduto)
        {
            context.Update(tipoProduto);
            context.SaveChanges();
            return tipoProduto.Id;
        }

        public int Get(Tipoproduto tipoProduto)
        {
            return context.Tipoprodutos.Find(tipoProduto.Id);
        }

        public IEnumerable<Tipoproduto> GetAll()
        {
            return context.Tipoprodutos.AsNoTracking();
        }

        public IEnumerable<Tipoproduto> GetByNome(string nome)
        {
            var query = from tipoProduto in context.Tipoprodutos
                        where tipoProduto.Nome.StartsWith(nome)
                        orderby tipoProduto.Nome
                        select tipoProduto;
            return query;
        }
    }
}