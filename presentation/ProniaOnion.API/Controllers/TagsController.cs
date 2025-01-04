using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Tags;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : Controller
    {
   
        private readonly IRepository<Tag> _repository;
        private readonly ITagService _tagService;

        public TagsController(IRepository<Tag> repository, ITagService tagService)
        {
            _repository = repository;
            _tagService = tagService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK, await _tagService.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return BadRequest();

            var tagDTO = await _tagService.GetByIdAsync(id);

            if (tagDTO == null) return NotFound();

            return StatusCode(StatusCodes.Status200OK, tagDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateTagDto tagDTO)
        {
            await _tagService.CreateAsync(tagDTO);
            //    return BadRequest();

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateTagDto tagDTO)
        {
            if (id < 1)
                return BadRequest();

            await _tagService.UpdateTagAsync(id, tagDTO);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            await _tagService.DeleteTagAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}

