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
            context.Add(produto);
            context.SaveChanges();
            return produto.Id;
        }

        public bool Delete(Produto produto)
        {
            context.Remove(produto);
            context.SaveChanges();
            return true;
        }

        public int Edit(Produto produto)
        {
            context.Update(produto);
            context.SaveChanges();
            return produto.Id;
        }

        public int Get(Produto produto)
        {
            return context.Produtos.Find(produto.Id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return context.Produtos.AsNoTracking();
        }

        public IEnumerable<Produto> GetByNome(string nome)
        {
            var query = from produto in context.Produtos
                        where produto.Nome.StartsWith(nome)
                        orderby produto.Nome
                        select produto;
            return query;
        }
    }
}