namespace Core.Service
{
    public interface IProdutoService
    {
        public int Get(int produto);
        public int Create(Produto produto);
        public int Edit(Produto produto);
        public bool Delete(Produto produto);

        IEnumerable<Produto> GetAll();
        IEnumerable<Produto> GetByNome(string nome);
    }
}
