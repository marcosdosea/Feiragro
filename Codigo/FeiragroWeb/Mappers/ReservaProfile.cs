using System;
using Core;
using FeiragroWeb.Models;
using AutoMapper;

namespace FeiragroWeb.Mappers
{
	public class ReservaProfile : Profile
	{
		public ReservaProfile()
		{
            CreateMap<ReservaModel, Reserva>().ReverseMap();
        }
	}
}

