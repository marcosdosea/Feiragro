using AutoMapper;
using Core;
using FeiragroAPI.Models;

namespace FeiragroAPI.Mappers
{
    public class AssociacaoProfile : Profile
    {
        public AssociacaoProfile()
        {
            CreateMap<AssociacaoModel, Associacao>().ReverseMap();
        }
    }
}