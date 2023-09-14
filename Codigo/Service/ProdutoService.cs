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

        /// <summary>
        /// Funcao para Criar um Produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns>id do Produto</returns>
        public int Create(Produto produto)
        {
            context.Add(produto);
            context.SaveChanges();
            return produto.Id;
        }

        /// <summary>
        /// Funcao para Deletar um Produto
        /// </summary>
        /// <param name="idProduto"></param>
        /// <returns></returns>
        public void Delete(int idProduto)
        {
            var produto = context.Produtos.Find(idProduto);
            context.Remove(produto!);
            context.SaveChanges();
        }

        /// <summary>
        /// Funcao para Editar um Produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public void Edit(Produto produto)
        {
            context.Update(produto);
            context.SaveChanges();
        }

        /// <summary>
        /// Funcao para Pesquisar um Produto
        /// </summary>
        /// <param name="idProduto"></param>
        /// <returns>O Produto</returns>
        public Produto Get(int idProduto)
        {
            return context.Produtos.Find(idProduto)!;
        }

        /// <summary>
        /// Funcao para Pesquisar os Produtos
        /// </summary>
        /// <returns>Lista os Produtos</returns>
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
