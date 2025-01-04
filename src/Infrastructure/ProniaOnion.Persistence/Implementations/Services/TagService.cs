using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Tags;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class TagService : ITagService

    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<TagItemDto> categories = await _tagRepository.GetAll(skip: (page - 1) * take, take: take)
                .Select(x => _mapper.Map<TagItemDto>(x))
            .ToListAsync();
            return categories;

        }

        public async Task<GetTagDto> GetByIdAsync(int id)
        {
            Tag tag = await _tagRepository.GetByIdAsync(id, "ProductTags.Product");
            if (tag == null) return null;
            var tagDto = _mapper.Map<GetTagDto>(tag);
            return tagDto;
        }
        public async Task CreateAsync(CreateTagDto tagDto)
        {
            if (await _tagRepository.AnyAsync(c => c.Name == tagDto.Name))
                throw new Exception("Tag exist");

            var tag = _mapper.Map<Tag>(tagDto);

            tag.CreatedAt = DateTime.Now;
            tag.UpdatedAt = DateTime.Now;

            await _tagRepository.AddAsync(tag);
            await _tagRepository.SaveChangesAsync();
        }

        public async Task UpdateTagAsync(int id, UpdateTagDto tagDto)
        {
            Tag tag = await _tagRepository.GetByIdAsync(id);
            if (tag == null)
                throw new Exception("Not found");

            if (await _tagRepository.AnyAsync(c => c.Name == tagDto.Name && c.Id == id))
                throw new Exception("Exists");
            _mapper.Map(tagDto, tag);
            tag.UpdatedAt = DateTime.Now;

            // tag = _mapper.Map<Tag>(tagDto);
            _tagRepository.Update(tag);
            await _tagRepository.SaveChangesAsync();
        }

        public async Task DeleteTagAsync(int id)
        {
            Tag tag = await _tagRepository.GetByIdAsync(id);

            if (tag == null)
                throw new Exception("Not found");

            _tagRepository.Delete(tag);
            await _tagRepository.SaveChangesAsync();
        }

    }
}
