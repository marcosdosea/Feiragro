using Core;
using Core.Service;

namespace Service
{
    public class PessoaService : IPessoaService
    {
        private readonly FeiragroContext context;


        public PessoaService(FeiragroContext context)
        {
            this.context = context;
        }

        public int Create(Pessoa pessoa)
        {
            context.Add(pessoa);
            context.SaveChanges();
            return pessoa.Id;
        }

        public bool Delete(Pessoa pessoa)
        {
            context.Remove(pessoa);
            context.SaveChanges();
            return true;
        }

        public int Edit(Pessoa pessoa)
        {
            context.Update(pessoa);
            context.SaveChanges();
            return pessoa.Id;
        }

        public int Get(Pessoa pessoa)
        {
            return context.Pessoas.Find(pessoa.Id);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return context.Pessoas.AsNoTracking();
        }

        public IEnumerable<Pessoa> GetByNome(string nome)
        {
            var query = from pessoa in context.Pessoas
                        where pessoa.Nome.StartsWith(nome)
                        orderby pessoa.Nome
                        select pessoa;
            return query;
        }
    }
}