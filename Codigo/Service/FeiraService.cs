using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class FeiraService : IFeiraService
    {
        public readonly FeiragroContext _context;

        public FeiraService(FeiragroContext context)
        {  
            _context = context;
        }
        /// <summary>
        /// Funcao para criar um FeiraService
        /// </summary>
        /// <param name="feira"></param>
        /// <returns>id da feira</returns>
        public int Create(Feira feira)
        {
            _context.Add(feira);
            _context.SaveChanges();
            return feira.Id;
        }
        /// <summary>
        /// Funcao para Deletar uma feira
        /// </summary>
        /// <param name="idFeira"></param>
        /// <returns></returns>
        public void Delete(int idFeira)
        {
            var feira = _context.Feiras.Find(idFeira);
            _context.Remove(feira);
            _context.SaveChanges();
        }
        /// <summary>
        /// Funcao para Editar uma feira
        /// </summary>
        /// <param name="feira"></param>
        /// <returns>A Feira</returns>
        public void Edit(Feira feira)
        {
            _context.Update(feira);
            _context.SaveChanges();
        }
        /// <summary>
        /// Funcao para Pesquisar uma feira por id
        /// </summary>
        /// <param name="idFeira"></param>
        /// <returns>A feira</returns>
        public Feira Get(int idFeira)
        {
            return _context.Feiras.Find(idFeira)!;
        }

        /// <summary>
        /// Funcao para Pesquisar todas as feiras
        /// </summary>
        /// <returns>Lista com todas as feiras</returns>
        public IEnumerable<Feira> GetAll()
        {
            return _context.Feiras.AsNoTracking();
        }

        /// <summary>
        /// Funcao para consultar as Feiras na Associacao pelo nome
        /// </summary>
        /// <param name="feira"></param>
        /// <returns></returns>
        public IEnumerable<Feira> GetByIdAssociacao(int idAssociacao)
        {
            var query = from feira in _context.Feiras
                        where feira.IdAssociacao == idAssociacao
                        select feira;
            return query;
        }

    }
}
