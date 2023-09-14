using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class PontoAssociacaoService : IPontoAssociacaoService
    {
        private readonly FeiragroContext _context;
        public PontoAssociacaoService(FeiragroContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Funcao para criar um Ponto de Venda
        /// </summary>
        /// <param name="pontoVenda"></param>
        /// <returns>id do Ponto de Venda</returns>
        public int Create(Pontoassociacao pontoVenda)
        {
            _context.Add(pontoVenda);
            _context.SaveChanges();
            return pontoVenda.Id;
        }

        /// <summary>
        /// Funcao para Deletar um Ponto de Venda
        /// </summary>
        /// <param name="idPontoVenda"></param>
        /// <returns></returns>
        public void Delete(int idPontoVenda)
        {
            var pontoVenda = _context.Pontoassociacaos.Find(idPontoVenda);
            _context.Remove(pontoVenda!);
            _context.SaveChanges();
        }

        /// <summary>
        /// Funcao para Editar um Ponto de Venda
        /// </summary>
        /// <param name="pontoVenda"></param>
        /// <returns></returns>
        public void Edit(Pontoassociacao pontoVenda)
        {
            _context.Update(pontoVenda);
            _context.SaveChanges();
        }

        /// <summary>
        /// Funcao para Pesquisar um Ponto de Venda
        /// </summary>
        /// <param name="idPontoVenda"></param>
        /// <returns>O Ponto de Venda</returns>
        public Pontoassociacao Get(int idPontoVenda)
        {
            return _context.Pontoassociacaos.Find(idPontoVenda)!;
        }

        /// <summary>
        /// Funcao para Pesquisar os Pontos de Venda
        /// </summary>
        /// <returns>Lista com os pontos de venda</returns>
        public IEnumerable<Pontoassociacao> GetAll()
        {
            return _context.Pontoassociacaos.AsNoTracking();
        }

        public IEnumerable<Pontoassociacao> GetByIdAssociacao(int id)
        {
            var query = from pontoVenda in _context.Pontoassociacaos
                        where pontoVenda.IdAssociacao == id
                        select pontoVenda;
            return query.AsNoTracking();
        }
    }
}
