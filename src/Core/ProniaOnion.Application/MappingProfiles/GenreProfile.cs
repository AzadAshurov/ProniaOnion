using AutoMapper;
using ProniaOnion.Application.DTOs.Genres;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreItemDto>();
            CreateMap<Genre, GetGenreDto>().ReverseMap();
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDto, Genre>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
