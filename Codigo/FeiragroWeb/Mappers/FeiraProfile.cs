using AutoMapper;
using Core;
using FeiragroWeb.Models;

namespace FeiragroWeb.Mappers
{
    public class FeiraProfile : Profile
    {
        public FeiraProfile() 
        { 
            CreateMap<FeiraModel, Feira>().ReverseMap();
        }
    }
}
