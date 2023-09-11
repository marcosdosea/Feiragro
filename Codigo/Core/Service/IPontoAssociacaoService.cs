namespace Core.Service
{
    public interface IPontoAssociacaoService
    {
        public Pontoassociacao Get(int id);
        public int Create(Pontoassociacao pontoVenda);
        public void Edit(Pontoassociacao pontoVenda);
        public void Delete(int id);

        IEnumerable<Pontoassociacao> GetAll();
        IEnumerable<Pontoassociacao> GetByIdAssociacao(int id);

    }
}
