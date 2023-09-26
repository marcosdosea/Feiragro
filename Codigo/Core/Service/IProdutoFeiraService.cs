namespace Core.Service
{
    public interface IProdutoFeiraService
    {
        public Produtofeira Get(Produtofeira produtofeira);
        public int Create(Produtofeira produtofeira);
        public void Edit(Produtofeira produtofeira);
        public void Delete(Produtofeira produtofeira);

        IEnumerable<Produtofeira> GetAll();
        IEnumerable<Produtofeira> GetByNome(string nome);
    }
}
