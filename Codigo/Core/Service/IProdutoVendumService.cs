namespace Core.Service
{
    public interface IProdutoVendumService
    {
        public int Get(Produtovendum produto);
        public int Create(Produtovendum produto);
        public int Edit(Produtovendum produto);
        public bool Delete(Produtovendum produto);

        IEnumerable<Produtovendum> GetAll();
        IEnumerable<Produtovendum> GetByNome(string nome);
    }
}
