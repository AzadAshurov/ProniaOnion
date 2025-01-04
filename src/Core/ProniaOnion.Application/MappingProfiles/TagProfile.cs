
using AutoMapper;
using ProniaOnion.Application.DTOs.Tags;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {

            CreateMap<Tag, GetTagDto>()
               .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductTags));
            CreateMap<Tag, TagItemDto>();
            CreateMap<Tag, GetTagDto>().ReverseMap();
            CreateMap<CreateTagDto, Tag>();
            CreateMap<UpdateTagDto, Tag>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
