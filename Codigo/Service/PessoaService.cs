using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Service
{
    public class PessoaService : IPessoaService
    {
        private readonly FeiragroContext context;
        public PessoaService (FeiragroContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Funcao para criar uma Pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public int Create(Pessoa pessoa)
        {
            context.Add(pessoa);
            context.SaveChanges();
            return pessoa.Id;
        }
        /// <summary>
        /// Funcao para Deletar uma Pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>

        public void Delete(int idPessoa)
        {
            var pessoa = context.Pessoas.Find(idPessoa);
            context.Remove(pessoa!);
            context.SaveChanges();
        }
        /// <summary>
        /// Funcao para Editar uma Pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>

        public void Edit(Pessoa pessoa)
        {
           context.Update(pessoa);
            context.SaveChanges();
        }
        /// <summary>
        /// Funcao para procurar uma Pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>

        public Pessoa Get(int idPessoa)
        {
            return context.Pessoas.Find(idPessoa)!;
        }

        /// <summary>
        /// Funcao para retornar todas as Pessoas
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>

        public IEnumerable<Pessoa> GetAll()
        {
            return context.Pessoas.AsNoTracking();
        }

        /// <summary>
        /// Funcao para consultar todas as Pessoas através do nome
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>

        public IEnumerable<Pessoa> GetByNome(string nome)
        {
            var query = from pessoa in context.Pessoas
                        where pessoa.Nome.StartsWith(nome)
                        orderby pessoa.Nome
                        select pessoa;
            return query.AsNoTracking();



        }
    }
}
