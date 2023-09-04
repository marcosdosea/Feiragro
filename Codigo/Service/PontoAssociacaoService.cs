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

        public int Create(Pontoassociacao pontoVenda)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Pontoassociacao pontoVenda)
        {
            throw new NotImplementedException();
        }

        public int Edit(Pontoassociacao pontoVenda)
        {
            throw new NotImplementedException();
        }

        public int Get(Pontoassociacao pontoVenda)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pontoassociacao> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pontoassociacao> GetByIdAssociacao(int id)
        {
            throw new NotImplementedException();
        }
    }
}
