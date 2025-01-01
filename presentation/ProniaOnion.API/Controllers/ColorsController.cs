using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Colors;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ColorsController : Controller
    {
        private readonly IRepository<Color> _repository;
        private readonly IColorService _colorService;

        public ColorsController(IRepository<Color> repository, IColorService colorService)
        {
            _repository = repository;
            _colorService = colorService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK, await _colorService.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return BadRequest();

            var colorDTO = await _colorService.GetByIdAsync(id);

            if (colorDTO == null) return NotFound();

            return StatusCode(StatusCodes.Status200OK, colorDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateColorDto colorDTO)
        {
            await _colorService.CreateAsync(colorDTO);
            //    return BadRequest();

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateColorDto colorDTO)
        {
            if (id < 1)
                return BadRequest();

            await _colorService.UpdateColorAsync(id, colorDTO);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            await _colorService.DeleteColorAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
