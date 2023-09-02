


using Core.DTO;

namespace Core.Service
{
    public interface ITipoProdutoService
    {
        public int Get(TipoProduto tipoProduto);
        public int Create(TipoProduto tipoProduto);
        public int Edit(TipoProduto tipoProduto);
        public bool Delete(TipoProduto tipoProduto);

        IEnumerable<TipoProduto> GetAll();
        IEnumerable<TipoProdutoDto> GetByNome(string nome);
    }
}
