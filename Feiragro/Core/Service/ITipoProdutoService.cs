namespace Core.Service
{
    public interface ITipoProdutoService
    {
        public int Get(Tipoproduto tipoProduto);
        public int Create(Tipoproduto tipoProduto);
        public int Edit(Tipoproduto tipoProduto);
        public bool Delete(Tipoproduto tipoProduto);

        IEnumerable<Tipoproduto> GetAll();
        IEnumerable<Tipoproduto> GetByNome(string nome);
    }
}
