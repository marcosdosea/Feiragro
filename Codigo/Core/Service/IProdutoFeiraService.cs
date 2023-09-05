namespace Core.Service
{
    public interface IProdutoFeiraService
    {
        public int Get(Produtofeira produtofeira);
        public int Create(Produtofeira produtofeira);
        public int Edit(Produtofeira produtofeira);
        public bool Delete(Produtofeira produtofeira);

        IEnumerable<Produtofeira> GetAll();
        IEnumerable<Produtofeira> GetByIdFeira(int id);
    }
}
