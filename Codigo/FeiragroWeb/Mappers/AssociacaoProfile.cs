using AutoMapper;
using Core;
using FeiragroWeb.Models;

namespace FeiragroWeb.Mappers
{
    public class AssociacaoProfile : Profile
    {
        public AssociacaoProfile()
        {
            CreateMap<PontoAssociacaoModel, Associacao>().ReverseMap();
        }
    }
}