using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class FeiraService : IFeiraService
    {
        private readonly FeiragroContext context;


        public FeiraService(FeiragroContext context)
        {
            this.context = context;
        }
        public int Create(Feira feira)
        {
            context.Add(feira);
            context.SaveChanges();
            return feira.Id;
        }
        public bool Delete(Feira feira)
        {
            context.Remove(feira);
            context.SaveChanges();
            return true;
        }
        public int Edit(Feira feira)
        {
            context.Update(feira);
            context.SaveChanges();
            return feira.Id;
        }

        public int Get(Feira feira)
        {
            return context.Feiras.Find(feira.Id);
        }

        public IEnumerable<Feira> GetAll()
        {
            return context.Feiras.AsNoTracking();
        }

        public IEnumerable<Feira> GetByIdAssociacao(int id)
        {
            var query = from feira in context.Feiras
                        where feira.IdAssociacao == id
                        orderby feira.Id
                        select feira;
            return query;
        }
    }
}
