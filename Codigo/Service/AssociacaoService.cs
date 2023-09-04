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

        public int Create(Associacao associacao)
        {
            context.Add(associacao);
            context.SaveChanges();
            return associacao.Id;
        }

        public bool Delete(Associacao associacao)
        {
            context.Remove(associacao);
            context.SaveChanges();
            return true;
        }

        public int Edit(Associacao associacao)
        {
            context.Update(associacao);
            context.SaveChanges();
            return associacao.Id;
        }

        public int Get(Associacao associacao)
        {
            return context.Associacaos.Find(associacao.Id);
        }

        public IEnumerable<Associacao> GetAll()
        {
            return context.Associacaos.AsNoTracking();
        }

        public IEnumerable<Associacao> GetByCnpjAssociacao(string cnpj)
        {
            var query = from associacao in context.Associacaos
                        where associacao.Cnpj.StartsWith(cnpj)
                        orderby associacao.Cnpj
                        select associacao;
            return query;
        }
    }
}
