using AutoMapper;
using Core;
using FeiragroAPI.Models;

namespace FeiragroAPI.Mappers
{
    public class FeiraProfile : Profile
    {
        public FeiraProfile() 
        {
            CreateMap<FeiraModel, Feira>().ReverseMap();
        }
    }
}
