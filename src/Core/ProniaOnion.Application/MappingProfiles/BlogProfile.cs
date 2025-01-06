using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProniaOnion.Application.DTOs.Blogs;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {

            CreateMap<Blog, GetBlogDto>()
               .ForMember(dest => dest.TagItemDtos, opt => opt.MapFrom(src => src.BlogTags));
            CreateMap<Blog, BlogItemDto>();
            CreateMap<Blog, GetBlogDto>().ReverseMap();
            CreateMap<CreateBlogDto, Blog>();
            CreateMap<UpdateBlogDto, Blog>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
