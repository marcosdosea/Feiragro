using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ProdutoFeiraService : IProdutoFeiraService
    {
        private readonly FeiragroContext _context;
        public ProdutoFeiraService(FeiragroContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Funcao para criar sum Produto
        /// </summary>
        /// <param name="produtofeira"></param>
        /// <returns>id do produto</returns>
        public int Create(Produtofeira produtofeira)
        {
            _context.Add(produtofeira);
            _context.SaveChanges();
            return produtofeira.IdFeira;
        }

        /// <summary>
        /// Funcao para Deletar um Produto da feira
        /// </summary>
        /// <param name="produtofeira"></param>
        /// <returns></returns>
        public void Delete(int idFeira, int idProduto)
        {

            var produtoFeira = _context.Produtofeiras.Find(idFeira, idProduto);
            _context.Remove(produtoFeira!);
        }

        /// <summary>
        /// Funcao para Editar um Produto da Feira
        /// </summary>
        /// <param name="produtofeira"></param>
        /// <returns>/returns>
        public void Edit(Produtofeira produtofeira)
        {
            _context.Update(produtofeira);
            _context.SaveChanges();
        }

        /// <summary>
        /// Funcao para Pesquisar Produtos da Feira
        /// </summary>
        /// <param name="produtofeira"></param>
        /// <returns>O Produto da feira</returns>
        public Produtofeira Get(int idFeira, int idProduto)
        {
            return _context.Produtofeiras.Find(idFeira, idProduto)!;
        }

        /// <summary>
        /// Funcao para Pesquisar tods os produtos da feira
        /// </summary>
        /// <returns>Lista com todas as Associacoes</returns>
        public IEnumerable<Produtofeira> GetAll()
        {
            return _context.Produtofeiras.AsNoTracking();
        }

        /// <summary>
        /// Funcao para consultar os produtos da feira
        /// </summary>
        /// <param name="produtofeira"></param>
        /// <returns></returns>
        public IEnumerable<Produtofeira> GetByIdFeira(int idFeira)
        {
            return _context.Produtofeiras
            .Where(produtofeira => produtofeira.IdFeira == idFeira)
            .ToList();
        }
    }
}