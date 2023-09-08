namespace Core.Service
{
    public interface ITipoProdutoService
    {
        public Tipoproduto Get(int tipoProduto);
        public bool Create(Tipoproduto tipoProduto);
        public Tipoproduto? Edit(Tipoproduto tipoProduto);
        public bool Delete(Tipoproduto tipoProduto);

        IEnumerable<Tipoproduto> GetAll();
        IEnumerable<Tipoproduto> GetByNome(string nome);
    }
}
