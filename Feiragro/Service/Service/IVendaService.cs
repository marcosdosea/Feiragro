
using Core.DTO;

namespace Core.Service
{
    public interface IVendaService
    {
        public int Get(Venda venda);
        public int Edit(Venda venda);
        IEnumerable<Venda> GetAll();
        IEnumerable<VendaDto> GetByIdPessoa(int id);
    }
}
