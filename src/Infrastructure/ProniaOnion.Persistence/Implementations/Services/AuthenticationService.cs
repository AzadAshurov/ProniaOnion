using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.AppUsers;
using ProniaOnion.Domain.Entities.Identity;
using System.Text;

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

        public async Task LoginAsync(LoginDto userDto)
        {
            AppUser? user = userDto.UserNameOrEmail.Contains("@") ? await _userManager.Users.FirstOrDefaultAsync(x => x.Email == userDto.UserNameOrEmail) : await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userDto.UserNameOrEmail);
            if (user == null)
                throw new Exception("Username , Email or Password is invalid");
            bool result = await _userManager.CheckPasswordAsync(user, userDto.Password);
            if (!result)
            {
                await _userManager.AccessFailedAsync(user);
                throw new Exception("Username , Email or Password is invalid");
            }
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
