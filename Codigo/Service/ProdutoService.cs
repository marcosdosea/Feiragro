using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

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

        public void Delete(int idProduto)
        {
            var produto = context.Produtos.Find(idProduto);
            context.Remove(produto);
            context.SaveChanges();
        }

        public void Edit(Produto produto)
        {
            context.Update(produto);
            context.SaveChanges();
        }

        public Produto Get(int idProduto)
        {
            return context.Produtos.Find(idProduto)!;
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
