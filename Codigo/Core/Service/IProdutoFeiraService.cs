namespace Core.Service
{
    public interface IProdutoFeiraService
    {
        public Produtofeira Get(int idFeira, int idProduto);
        public int Create(Produtofeira produtofeira);
        public void Edit(Produtofeira produtofeira);
        public void Delete(int idFeira, int idProduto);

        IEnumerable<Produtofeira> GetAll();
        IEnumerable<Produtofeira> GetByIdFeira(int idFeira);
    }
}