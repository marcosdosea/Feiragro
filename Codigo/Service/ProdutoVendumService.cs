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

        public int Create(Produtovendum produtoVenda)
        {
            context.Add(produtoVenda);
            context.SaveChanges();
            return produtoVenda.IdFeira;
        }

        public bool Delete(Produtovendum produtoVenda)
        {
            context.Remove(produtoVenda);
            context.SaveChanges();
            return true;
        }

        public int Edit(Produtovendum produtoVenda)
        {
            context.Update(produtoVenda);
            context.SaveChanges();
            return produtoVenda.IdFeira;
        }

        public int Get(Produtovendum produtoVenda)
        {
            return context.Produtovenda.Find(produtoVenda.IdFeira);
        }

        public IEnumerable<Produtovendum> GetAll()
        {
            return context.Produtovenda.AsNoTracking();
        }

        public IEnumerable<Produtovendum> GetByIdFeira(int id)
        {
            var query = from produtoVenda in context.Produtovenda
                        where produtoVenda.IdFeira == id
                        select produtoVenda;
            return query;
        }
    }
}