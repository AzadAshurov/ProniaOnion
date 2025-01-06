using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Sizes;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class SizeService : ISizeService

    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SizeItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<SizeItemDto> categories = await _sizeRepository.GetAll(skip: (page - 1) * take, take: take)
                .Select(x => _mapper.Map<SizeItemDto>(x))
            .ToListAsync();
            return categories;

        }

        public async Task<GetSizeDto> GetByIdAsync(int id)
        {
            Size size = await _sizeRepository.GetByIdAsync(id, "ProductSizes.Product");
            if (size == null) return null;
            var sizeDto = _mapper.Map<GetSizeDto>(size);
            return sizeDto;
        }
        public async Task CreateAsync(CreateSizeDto sizeDto)
        {
            if (await _sizeRepository.AnyAsync(c => c.Name == sizeDto.Name))
                throw new Exception("Size exist");

            var size = _mapper.Map<Size>(sizeDto);

            size.CreatedAt = DateTime.Now;
            size.UpdatedAt = DateTime.Now;

            await _sizeRepository.AddAsync(size);
            await _sizeRepository.SaveChangesAsync();
        }

        public async Task UpdateSizeAsync(int id, UpdateSizeDto sizeDto)
        {
            Size size = await _sizeRepository.GetByIdAsync(id);
            if (size == null)
                throw new Exception("Not found");

            if (await _sizeRepository.AnyAsync(c => c.Name == sizeDto.Name && c.Id != id))
                throw new Exception("Exists");
            _mapper.Map(sizeDto, size);
            size.UpdatedAt = DateTime.Now;

            // size = _mapper.Map<Size>(sizeDto);
            _sizeRepository.Update(size);
            await _sizeRepository.SaveChangesAsync();
        }

        public async Task DeleteSizeAsync(int id)
        {
            Size size = await _sizeRepository.GetByIdAsync(id);

            if (size == null)
                throw new Exception("Not found");

            _sizeRepository.Delete(size);
            await _sizeRepository.SaveChangesAsync();
        }

    }
}
