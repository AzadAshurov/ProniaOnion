using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.AppUsers;

namespace ProniaOnion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterDto userDto)
        {
            await _service.RegisterAsync(userDto);
            return NoContent();
        }

    }
}
