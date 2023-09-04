namespace Core.Service
{
    public interface IPessoaService
    {
        public int Get(Pessoa pessoa);
        public int Create(Pessoa pessoa);
        public int Edit(Pessoa pessoa);
        public bool Delete(Pessoa pessoa);

        IEnumerable<Pessoa> GetAll();
        IEnumerable<Pessoa> GetByNome(string nome);
    }
}
