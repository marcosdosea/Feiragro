using Core;
using Core.Service;

namespace Service
{
    public class VendumService : IVendumService
    {
        private readonly FeiragroContext context;


        public VendumService(FeiragroContext context)
        {
            this.context = context;
        }

        public int Create(Vendum vendum)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Vendum vendum)
        {
            throw new NotImplementedException();
        }

        public int Edit(Vendum vendum)
        {
            throw new NotImplementedException();
        }

        public int Get(Vendum vendum)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vendum> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vendum> GetByNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
