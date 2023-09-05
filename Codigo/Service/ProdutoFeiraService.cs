using Core;
using Core.Service;

namespace Service
{
    public class ProdutoFeiraService : IProdutoFeiraService
    {
        private readonly FeiragroContext context;


        public ProdutoFeiraService(FeiragroContext context)
        {
            this.context = context;
        }

        public int Create(Produtofeira produtofeira)
        {
            context.Add(produtofeira);
            context.SaveChanges();
            return produtofeira.IdFeira;
        }

        public bool Delete(Produtofeira produtofeira)
        {
            context.Remove(produtofeira);
            context.SaveChanges();
            return true;
        }

        public int Edit(Produtofeira produtofeira)
        {
            context.Update(produtofeira);
            context.SaveChanges();
            return produtofeira.IdFeira;
        }

        public int Get(Produtofeira produtofeira)
        {
            return context.Produtofeiras.Find(produtofeira.IdFeira);
        }

        public IEnumerable<Produtofeira> GetAll()
        {
            return context.Produtofeiras.AsNoTracking();
        }

        public IEnumerable<Produtofeira> GetByIdFeira(int idFeira)
        {
            var query = from produtoFeira in context.Produtofeiras
                        where produtoFeira.IdFeira == idFeira
                        orderby produtoFeira.IdFeira
                        select produtoFeira;
            return query;
        }
    }
}