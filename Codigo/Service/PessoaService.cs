﻿using Core;
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
            throw new NotImplementedException();
        }

        public bool Delete(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public int Edit(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public int Get(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pessoa> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pessoa> GetByNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
