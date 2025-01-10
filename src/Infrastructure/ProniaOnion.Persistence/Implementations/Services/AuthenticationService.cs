using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.AppUsers;
using ProniaOnion.Domain.Entities.Identity;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AuthenticationService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task RegisterAsync(RegisterDto userDto)
        {
            if (await _userManager.Users.AnyAsync(u => u.UserName == userDto.UserName || u.Email == userDto.Email))
                throw new Exception("User already exists");

            var result = await _userManager.CreateAsync(_mapper.Map<AppUser>(userDto), userDto.Password);
            if (!result.Succeeded)
            {
                StringBuilder str = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    str.AppendLine(error.Description);
                }
                throw new Exception(str.ToString());
            }
        }
    }

}
