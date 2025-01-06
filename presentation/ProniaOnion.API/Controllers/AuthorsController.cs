using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Authors;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly IRepository<Author> _repository;
        private readonly IAuthorService _authorService;

        public AuthorsController(IRepository<Author> repository, IAuthorService authorService)
        {
            _repository = repository;
            _authorService = authorService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK, await _authorService.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return BadRequest();

            var authorDTO = await _authorService.GetByIdAsync(id);

            if (authorDTO == null) return NotFound();

            return StatusCode(StatusCodes.Status200OK, authorDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateAuthorDto authorDTO)
        {
            await _authorService.CreateAsync(authorDTO);
            //    return BadRequest();

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateAuthorDto authorDTO)
        {
            if (id < 1)
                return BadRequest();

            await _authorService.UpdateAuthorAsync(id, authorDTO);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            await _authorService.DeleteAuthorAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
