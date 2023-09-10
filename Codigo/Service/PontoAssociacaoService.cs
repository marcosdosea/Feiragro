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
    

        public int Create(Pontoassociacao pontoVenda)
        {
            _context.Add(pontoVenda);
            _context.SaveChanges();
            return pontoVenda.Id;
        }

        public void Delete(int idPontoVenda)
        {
            var pontoVenda = _context.Pontoassociacaos.Find(idPontoVenda);
            _context.Remove(pontoVenda!);
            _context.SaveChanges();
        }

        public void Edit(Pontoassociacao pontoVenda)
        {
            _context.Update(pontoVenda);
            _context.SaveChanges();
        }

        public Pontoassociacao Get(int idPontoVenda)
        {
            return _context.Pontoassociacaos.Find(idPontoVenda)!;
        }

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
