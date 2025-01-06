using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProniaOnion.Application.DTOs.Authors;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {

            //CreateMap<Author, GetAuthorDto>()
            //   .ForMember(dest => dest.TagItemDtos, opt => opt.MapFrom(src => src.AuthorTags));
            CreateMap<Author, AuthorItemDto>();
            CreateMap<Author, GetAuthorDto>().ReverseMap();
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
