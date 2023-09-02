

using Core.DTO;

namespace Core.Service
{
    public interface IFeiraService
    {
        public int Get(Feira feira);
        public int Create(Feira feira);
        public int Edit(Feira feira);
        IEnumerable<Feira> GetAll();
        IEnumerable<FeiraDto> GetByIdAssociacao(int id);
    }
}
