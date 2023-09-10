using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AssociacaoService : IAssociacaoService
    {
        private readonly FeiragroContext context;
        public AssociacaoService(FeiragroContext context)
        {
            this.context = context;
        }
        public Associacao Get(int idAssociacao)
        {
            return context.Associacaos.Find(idAssociacao)!;
        }
        public int Create(Associacao associacao)
        {
            context.Add(associacao);
            context.SaveChanges();
            return associacao.Id;
        }
        public void Edit(Associacao associacao)
        {
            context.Update(associacao);
            context.SaveChanges();
        }
        public void Delete(int idAssociacao)
        {
            var associacao = context.Associacaos.Find(idAssociacao);
            context.Remove(associacao!);
            context.SaveChanges();
        }
        public IEnumerable<Associacao> GetAll()
        {
            return context.Associacaos.AsNoTracking();
        }
        public IEnumerable<Associacao> GetByNome(string nome)
        {
            var query = from associacao in context.Associacaos
                        where associacao.Nome.StartsWith(nome)
                        orderby associacao.Nome
                        select associacao;
            return query;
        }
    }
}