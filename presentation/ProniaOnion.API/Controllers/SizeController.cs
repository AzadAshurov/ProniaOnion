using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Sizes;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SizesController : Controller
    {

        private readonly IRepository<Size> _repository;
        private readonly ISizeService _sizeService;

        public SizesController(IRepository<Size> repository, ISizeService sizeService)
        {
            _repository = repository;
            _sizeService = sizeService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK, await _sizeService.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return BadRequest();

            var sizeDTO = await _sizeService.GetByIdAsync(id);

            if (sizeDTO == null) return NotFound();

            return StatusCode(StatusCodes.Status200OK, sizeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateSizeDto sizeDTO)
        {
            await _sizeService.CreateAsync(sizeDTO);
            //    return BadRequest();

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateSizeDto sizeDTO)
        {
            if (id < 1)
                return BadRequest();

            await _sizeService.UpdateSizeAsync(id, sizeDTO);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            await _sizeService.DeleteSizeAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
