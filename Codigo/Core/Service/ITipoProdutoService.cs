namespace Core.Service
{
    public interface ITipoProdutoService
    {
        public Tipoproduto Get(int idTipoProduto);
        public int Create(Tipoproduto tipoProduto);
        public void Edit(Tipoproduto tipoProduto);
        public void Delete(int idTipoProduto);

        IEnumerable<Tipoproduto> GetAll();
        IEnumerable<Tipoproduto> GetByNome(string nome);
    }
}
