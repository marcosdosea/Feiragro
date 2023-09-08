namespace Core.Service
{
    public interface IProdutoService
    {
        public Produto Get(int idProduto);
        public int Create(Produto produto);
        public void Edit(Produto produto);
        public void Delete(int  idProduto);

        IEnumerable<Produto> GetAll();
        IEnumerable<Produto> GetByNome(string nome);
    }
}
