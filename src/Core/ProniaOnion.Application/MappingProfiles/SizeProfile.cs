
using AutoMapper;
using ProniaOnion.Application.DTOs.Sizes;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {

            CreateMap<Size, GetSizeDto>()
               .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductSizes));
            CreateMap<Size, SizeItemDto>();
            CreateMap<Size, GetSizeDto>().ReverseMap();
            CreateMap<CreateSizeDto, Size>();
            CreateMap<UpdateSizeDto, Size>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
