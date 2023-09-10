using AutoMapper;
using Core;
using FeiragroWeb.Models;

namespace FeiragroWeb.Mappers
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile() 
        {
            CreateMap<PessoaModel, Pessoa>().ReverseMap();
        }
     
    }
}
