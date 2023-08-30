

using Core.DTO;

namespace Core.Service
{
    public interface IPontoVendaService
    {
        public int Get(PontoVenda pontoVenda);
        public int Create(PontoVenda pontoVenda);
        public int Edit(PontoVenda pontoVenda);
        public bool Delete(PontoVenda pontoVenda);

        IEnumerable<PontoVenda> GetAll();
        IEnumerable<PontoVendaDto> GetByIdAssociacao(int id);

    }
}
