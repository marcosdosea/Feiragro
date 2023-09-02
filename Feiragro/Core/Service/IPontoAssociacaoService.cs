namespace Core.Service
{
    public interface IPontoAssociacaoService
    {
        public int Get(Pontoassociacao pontoVenda);
        public int Create(Pontoassociacao pontoVenda);
        public int Edit(Pontoassociacao pontoVenda);
        public bool Delete(Pontoassociacao pontoVenda);

        IEnumerable<Pontoassociacao> GetAll();
        IEnumerable<Pontoassociacao> GetByIdAssociacao(int id);

    }
}
