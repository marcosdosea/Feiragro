using Core;
using Core.Service;

namespace Service
{
    public class PontoAssociacaoService : IPontoAssociacaoService
    {
        private readonly FeiragroContext context;


        public PontoAssociacaoService(FeiragroContext context)
        {
            this.context = context;
        }

        public int Create(Pontoassociacao pontoAssociacao)
        {
            context.Add(pontoAssociacao);
            context.SaveChanges();
            return pontoAssociacao.Id;
        }

        public bool Delete(Pontoassociacao pontoAssociacao)
        {
            context.Remove(pontoAssociacao);
            context.SaveChanges();
            return true;
        }

        public int Edit(Pontoassociacao pontoAssociacao)
        {
            context.Update(pontoAssociacao);
            context.SaveChanges();
            return pontoAssociacao.Id;
        }

        public int Get(Pontoassociacao pontoAssociacao)
        {
            return context.Pontoassociacaos.Find(pontoAssociacao.Id);
        }

        public IEnumerable<Pontoassociacao> GetAll()
        {
            return context.Pontoassociacaos.AsNoTracking();
        }

        public IEnumerable<Pontoassociacao> GetByIdAssociacao(int idAssociacao)
        {
            var query = from pontoAssociacao in context.Pontoassociacaos
                        where pontoAssociacao.IdAssociacao == idAssociacao
                        orderby pontoAssociacao.IdAssociacao
                        select pontoAssociacao;
            return query;
        }
    }
}
