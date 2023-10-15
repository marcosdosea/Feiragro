using AutoMapper;
using Core;
using FeiragroAPI.Models;

namespace FeiragroAPI.Mappers
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile() 
        {
            CreateMap<PessoaModel, Pessoa>().ReverseMap();
        }
     
    }
}
