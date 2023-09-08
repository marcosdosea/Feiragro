using AutoMapper;
using Core;
using FeiragroWeb.Models;

namespace FeiragroWeb.Mappers
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<ProdutoModel, Produto>().ReverseMap();
        }
    }
}
