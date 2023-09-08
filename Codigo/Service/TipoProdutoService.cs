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


        public int Create(Tipoproduto tipoProduto)
        {
            context.Add(tipoProduto);
            context.SaveChanges();
            return tipoProduto.Id;
        }

        public void Delete(int idTipoProduto)
        {
            var tipoProduto = context.Tipoprodutos.Find(idTipoProduto);
            context.Remove(tipoProduto);
            context.SaveChanges();
          
        }

        public void Edit(Tipoproduto tipoProduto)
        {
            context.Update(tipoProduto);
            context.SaveChanges();
        }

        public Tipoproduto Get(int tipoProduto)
        {
           return context.Tipoprodutos.Find(tipoProduto);
           
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
