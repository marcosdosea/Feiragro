using AutoMapper;
using Core;
using FeiragroWeb.Models;

namespace FeiragroWeb.Mappers
{
    public class PontoAssociacaoProfile : Profile
    {
        public PontoAssociacaoProfile()
        {
            CreateMap<PontoAssociacaoModel, Pontoassociacao>().ReverseMap();
        }
    }
}
