namespace Core.Service
{
    public interface IReservaProdutoFeiraService
    {
        public int Get(Reservaprodutofeira reservaprodutofeira);
        public int Create(Reservaprodutofeira reservaprodutofeira);
        public int Edit(Reservaprodutofeira reservaprodutofeira);
        public bool Delete(Reservaprodutofeira reservaprodutofeira);

        IEnumerable<Reservaprodutofeira> GetAll();
        IEnumerable<Reservaprodutofeira> GetByNome(string nome);
    }
}
