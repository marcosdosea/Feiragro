using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class TipoProdutoService : ITipoProdutoService
    {
        private readonly FeiragroContext context;
        public TipoProdutoService (FeiragroContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Funcao para criar um tipoProduto
        /// </summary>
        /// <param name="tipoProduto"></param>
        /// <returns></returns>
        public int Create(Tipoproduto tipoProduto)
        {
            context.Add(tipoProduto);
            context.SaveChanges();
            return tipoProduto.Id;
        }
        /// <summary>
        /// Funcao para Deletar um tipoProduto
        /// </summary>
        /// <param name="tipoProduto"></param>
        /// <returns></returns>
        public void Delete(int idTipoProduto)
        {
            var tipoProduto = context.Tipoprodutos.Find(idTipoProduto);
            context.Remove(tipoProduto!);
            context.SaveChanges();
          
        }
        /// <summary>
        /// Funcao para Editar um tipoProduto
        /// </summary>
        /// <param name="tipoProduto"></param>
        /// <returns></returns>
        public void Edit(Tipoproduto tipoProduto)
        {
            context.Update(tipoProduto);
            context.SaveChanges();
        }
        /// <summary>
        /// Funcao para procurar um tipoProduto
        /// </summary>
        /// <param name="tipoProduto"></param>
        /// <returns></returns>
        public Tipoproduto Get(int idTipoProduto)
        {
           return context.Tipoprodutos.Find(idTipoProduto)!;
           
        }
        /// <summary>
        /// Funcao para retornar todos os tipoProduto
        /// </summary>
        /// <param name="tipoProduto"></param>
        /// <returns></returns>
        public IEnumerable<Tipoproduto> GetAll()
        {
           return context.Tipoprodutos.AsNoTracking();
        }
        /// <summary>
        /// Funcao para consultar os tipoProdutos pelo nome
        /// </summary>
        /// <param name="tipoProduto"></param>
        /// <returns></returns>
        public IEnumerable<Tipoproduto> GetByNome(string nome)
        {
            var query = from tipoProduto in context.Tipoprodutos
                        where tipoProduto.Nome.StartsWith(nome)
                        orderby tipoProduto.Nome
                        select tipoProduto;
            return query.AsNoTracking();
        }
    }
}
