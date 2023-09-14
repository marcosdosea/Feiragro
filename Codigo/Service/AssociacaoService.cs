using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AssociacaoService : IAssociacaoService
    {
        private readonly FeiragroContext context;
        public AssociacaoService(FeiragroContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Funcao para Pesquisar uma Associacao
        /// </summary>
        /// <param name="idAssociacao"></param>
        /// <returns>A Associacao</returns>
        public Associacao Get(int idAssociacao)
        {
            return context.Associacaos.Find(idAssociacao)!;
        }

        /// <summary>
        /// Funcao para criar uma Associacao
        /// </summary>
        /// <param name="associacao"></param>
        /// <returns>id da reserva</returns>
        public int Create(Associacao associacao)
        {
            context.Add(associacao);
            context.SaveChanges();
            return associacao.Id;
        }

        /// <summary>
        /// Funcao para Editar uma Associacao
        /// </summary>
        /// <param name="associacao"></param>
        /// <returns>/returns>
        public void Edit(Associacao associacao)
        {
            context.Update(associacao);
            context.SaveChanges();
        }

        /// <summary>
        /// Funcao para Deletar uma Associacao
        /// </summary>
        /// <param name="idAssociacao"></param>
        /// <returns></returns>
        public void Delete(int idAssociacao)
        {
            var associacao = context.Associacaos.Find(idAssociacao);
            context.Remove(associacao!);
            context.SaveChanges();
        }

        /// <summary>
        /// Funcao para Pesquisar todas as Associacoes
        /// </summary>
        /// <returns>Lista com todas as Associacoes</returns>
        public IEnumerable<Associacao> GetAll()
        {
            return context.Associacaos.AsNoTracking();
        }
        public IEnumerable<Associacao> GetByNome(string nome)
        {
            var query = from associacao in context.Associacaos
                        where associacao.Nome.StartsWith(nome)
                        orderby associacao.Nome
                        select associacao;
            return query;
        }
    }
}