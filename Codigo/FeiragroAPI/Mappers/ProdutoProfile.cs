using AutoMapper;
using Core;
using FeiragroAPI.Models;

namespace FeiragroAPI.Mappers
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<ProdutoModel, Produto>().ReverseMap();
        }
    }
}
