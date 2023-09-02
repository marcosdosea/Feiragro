
using Core.DTO;

namespace Core.Service
{
    public interface IAssociacaoService
    {
        public int Get(Associacao associacao);
        public int Create(Associacao associacao);
        public int Edit(Associacao associacao);
        public bool Delete(Associacao associacao);

        IEnumerable<Associacao> GetAll();
        IEnumerable<AssociacaoDto> GetByIdAssociacao(int id);

    }
}
