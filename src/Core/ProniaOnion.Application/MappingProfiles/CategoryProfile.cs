using AutoMapper;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryItemDto>();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
