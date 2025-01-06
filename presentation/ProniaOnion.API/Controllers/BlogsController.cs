using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Blogs;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogsController : Controller
    {
        private readonly IRepository<Blog> _repository;
        private readonly IBlogService _blogService;

        public BlogsController(IRepository<Blog> repository, IBlogService blogService)
        {
            _repository = repository;
            _blogService = blogService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK, await _blogService.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return BadRequest();

            var blogDTO = await _blogService.GetByIdAsync(id);

            if (blogDTO == null) return NotFound();

            return StatusCode(StatusCodes.Status200OK, blogDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBlogDto blogDTO)
        {
            await _blogService.CreateAsync(blogDTO);
            //    return BadRequest();

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateBlogDto blogDTO)
        {
            if (id < 1)
                return BadRequest();

            await _blogService.UpdateBlogAsync(id, blogDTO);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            await _blogService.DeleteBlogAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
