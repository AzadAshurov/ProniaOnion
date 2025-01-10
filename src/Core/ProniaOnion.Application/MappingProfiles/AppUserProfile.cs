
using AutoMapper;
using ProniaOnion.Application.DTOs.AppUsers;
using ProniaOnion.Domain.Entities.Identity;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class AppUserProfile : Profile 
    {
        public AppUserProfile()
        {
            CreateMap<RegisterDto,  AppUser>();
        }
    }
}
