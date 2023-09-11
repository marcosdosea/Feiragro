namespace Core.Service
{
    public interface IFeiraService
    {
        public Feira Get(int idFeira);
        public int Create(Feira feira);
        public void Edit(Feira feira);
        public void Delete(int idFeira);
        IEnumerable<Feira> GetAll();
        IEnumerable<Feira> GetByIdAssociacao(int id);
    }
}
