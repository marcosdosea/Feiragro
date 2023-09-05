namespace Core.Service
{
    public interface IVendumService
    {
        public int Get(Vendum vendum);
        public int Create(Vendum vendum);
        public int Edit(Vendum vendum);
        public bool Delete(Vendum vendum);

        IEnumerable<Vendum> GetAll();
        IEnumerable<Vendum> GetByIdCliente(int id);
    }
}
