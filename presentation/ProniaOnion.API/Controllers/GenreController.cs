using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Genres;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IRepository<Genre> _repository;
        private readonly IGenreService _genreService;

        public GenreController(IRepository<Genre> repository, IGenreService genreService)
        {
            _repository = repository;
            _genreService = genreService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK, await _genreService.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return BadRequest();

            var genreDTO = await _genreService.GetByIdAsync(id);

            if (genreDTO == null) return NotFound();

            return StatusCode(StatusCodes.Status200OK, genreDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateGenreDto genreDTO)
        {
            await _genreService.CreateAsync(genreDTO);

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateGenreDto genreDTO)
        {
            if (id < 1)
                return BadRequest();

            await _genreService.UpdateGenreAsync(id, genreDTO);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            await _genreService.DeleteGenreAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
