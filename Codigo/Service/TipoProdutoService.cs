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
        /// <summary>
        /// Funcao para criar um tipoProdutoService
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
        /// Funcao para Deleta um tipoProdutoService
        /// </summary>
        /// <param name="tipoProduto"></param>
        /// <returns></returns>
        public void Delete(int idTipoProduto)
        {
            var tipoProduto = context.Tipoprodutos.Find(idTipoProduto);
            context.Remove(tipoProduto);
            context.SaveChanges();
          
        }
        /// <summary>
        /// Funcao para Editar um tipoProdutoService
        /// </summary>
        /// <param name="tipoProduto"></param>
        /// <returns></returns>
        public void Edit(Tipoproduto tipoProduto)
        {
            context.Update(tipoProduto);
            context.SaveChanges();
        }
        /// <summary>
        /// Funcao para procurar um tipoProdutoService
        /// </summary>
        /// <param name="tipoProduto"></param>
        /// <returns></returns>
        public Tipoproduto Get(int tipoProduto)
        {
           return context.Tipoprodutos.Find(tipoProduto);
           
        }
        /// <summary>
        /// Funcao para retornar todos os tipoProdutoService
        /// </summary>
        /// <param name="tipoProduto"></param>
        /// <returns></returns>
        public IEnumerable<Tipoproduto> GetAll()
        {
           return context.Tipoprodutos.AsNoTracking();
        }
        /// <summary>
        /// Funcao para consultar os tipoProdutoService pelo nome
        /// </summary>
        /// <param name="tipoProduto"></param>
        /// <returns></returns>
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
