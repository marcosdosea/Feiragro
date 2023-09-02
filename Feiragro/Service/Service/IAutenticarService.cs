
using Core.DTO;

namespace Core.Service
{
    public interface IAutenticarService
    {

        public Pessoa Get(PessoaDto pessoa);
        public Associacao Get(AssociacaoDto associacao);

    }
}
