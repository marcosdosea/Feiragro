namespace Core.Service
{
    public interface IProdutoVendumService
    {
        public int Get(Produtovendum produtoVendum);
        public int Create(Produtovendum produtoVendum);
        public int Edit(Produtovendum produtoVendum);
        public bool Delete(Produtovendum produtoVendum);

        IEnumerable<Produtovendum> GetAll();
        IEnumerable<Produtovendum> GetByIdFeira(int id);
    }
}