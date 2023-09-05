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

        public int Create(Vendum venda)
        {
            context.Add(venda);
            context.SaveChanges();
            return venda.Id;
        }

        public bool Delete(Vendum venda)
        {
            context.Remove(venda);
            context.SaveChanges();
            return true;
        }

        public int Edit(Vendum venda)
        {
            context.Update(venda);
            context.SaveChanges();
            return venda.Id;
        }

        public int Get(Vendum venda)
        {
            return context.Venda.Find(venda.Id);
        }

        public IEnumerable<Vendum> GetAll()
        {
            return context.Venda.AsNoTracking();
        }

        public IEnumerable<Vendum> GetByIdCliente(int idCliente)
        {
            var query = from venda in context.Venda
                        where venda.IdCliente == idCliente
                        orderby venda.IdCliente
                        select venda;
            return query;
        }
    }
}
