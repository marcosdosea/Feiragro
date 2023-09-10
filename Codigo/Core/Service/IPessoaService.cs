namespace Core.Service
{
    public interface IPessoaService
    {
        public Pessoa Get(int idPessoa);
        public int Create(Pessoa pessoa);
        public void Edit(Pessoa pessoa);
        public void Delete(int idPessoa);

        IEnumerable<Pessoa> GetAll();
        IEnumerable<Pessoa> GetByNome(string nome);
    }
}
