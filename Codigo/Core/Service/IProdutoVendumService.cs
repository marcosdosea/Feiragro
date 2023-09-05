namespace Core.Service
{
    public interface IProdutoVendumService
    {
        public int Get(Produtovendum produtoVenda);
        public int Create(Produtovendum produtoVenda);
        public int Edit(Produtovendum produtoVenda);
        public bool Delete(Produtovendum produtoVenda);

        IEnumerable<Produtovendum> GetAll();
        IEnumerable<Produtovendum> GetByIdFeira(int id);
    }
}