namespace Core.Service
{
    public interface IAssociacaoService
    {
        public Associacao Get(int idAssociacao);
        public int Create(Associacao associacao);
        public void Edit(Associacao associacao);
        public void Delete(int idAssociacao);
        IEnumerable<Associacao> GetAll();
        IEnumerable<Associacao> GetByNome(string nome);

    }
}
