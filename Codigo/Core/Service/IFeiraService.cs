﻿namespace Core.Service
{
    public interface IFeiraService
    {
        public int Get(Feira feira);
        public bool Delete(Feira feira);
        public int Create(Feira feira);
        public int Edit(Feira feira);
        IEnumerable<Feira> GetAll();
        IEnumerable<Feira> GetByIdAssociacao(int id);
    }
}