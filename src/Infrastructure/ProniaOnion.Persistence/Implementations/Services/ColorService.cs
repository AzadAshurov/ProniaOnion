using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Colors;
using ProniaOnion.Domain.Entities;
namespace ProniaOnion.Persistence.Implementations.Services
{
    public class ColorService : IColorService

    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ColorItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<ColorItemDto> categories = await _colorRepository.GetAll(skip: (page - 1) * take, take: take)
                .Select(x => _mapper.Map<ColorItemDto>(x))
            .ToListAsync();
            return categories;

        }

        public async Task<GetColorDto> GetByIdAsync(int id)
        {
            Color color = await _colorRepository.GetByIdAsync(id, "ProductColors.Product");
            if (color == null) return null;
            var colorDto = _mapper.Map<GetColorDto>(color);
            return colorDto;
        }
        public async Task CreateAsync(CreateColorDto colorDto)
        {
            if (await _colorRepository.AnyAsync(c => c.Name == colorDto.Name))
                throw new Exception("Color exist");

            var color = _mapper.Map<Color>(colorDto);

            color.CreatedAt = DateTime.Now;
            color.UpdatedAt = DateTime.Now;

            await _colorRepository.AddAsync(color);
            await _colorRepository.SaveChangesAsync();
        }

        public async Task UpdateColorAsync(int id, UpdateColorDto colorDto)
        {
            Color color = await _colorRepository.GetByIdAsync(id);
            if (color == null)
                throw new Exception("Not found");

            if (await _colorRepository.AnyAsync(c => c.Name == colorDto.Name && c.Id == id))
                throw new Exception("Exists");
            color.UpdatedAt = DateTime.Now;
            color = _mapper.Map<Color>(colorDto);
            _colorRepository.Update(color);
            await _colorRepository.SaveChangesAsync();
        }

        public async Task DeleteColorAsync(int id)
        {
            Color color = await _colorRepository.GetByIdAsync(id);

            if (color == null)
                throw new Exception("Not found");

            _colorRepository.Delete(color);
            await _colorRepository.SaveChangesAsync();
        }

    }
}
