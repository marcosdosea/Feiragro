using AutoMapper;
using Core;
using FeiragroWeb.Models;

namespace FeiragroWeb.Mappers
{
    public class TipoProdutoProfile : Profile
    {
        public TipoProdutoProfile() 
        {
            CreateMap<TipoProdutoModel, Tipoproduto>().ReverseMap();
        }
    }
}
