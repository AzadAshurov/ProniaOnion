﻿using AutoMapper;
using ProniaOnion.Application.DTOs.Colors;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
   public class ColorProfile : Profile
    {
        public ColorProfile()
        {

            CreateMap<Color, GetColorDto>()
               .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductColors));
            CreateMap<Color, ColorItemDto>();
            CreateMap<Color, GetColorDto>().ReverseMap();
            CreateMap<CreateColorDto, Color>();
            CreateMap<UpdateColorDto, Color>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
