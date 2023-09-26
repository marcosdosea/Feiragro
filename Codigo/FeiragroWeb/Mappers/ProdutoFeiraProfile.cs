using AutoMapper;
using Core;
using FeiragroWeb.Models;

namespace FeiragroWeb.Mappers
{
    public class ProdutoFeiraProfile : Profile
    {
        public ProdutoFeiraProfile()
        {
            CreateMap<ProdutoFeiraModel, Produtofeira>().ReverseMap();
        }
    }
}
