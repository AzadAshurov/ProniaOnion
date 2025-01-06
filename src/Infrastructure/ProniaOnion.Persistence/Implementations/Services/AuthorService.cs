
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Authors;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class AuthorService : IAuthorService

    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<AuthorItemDto> categories = await _authorRepository.GetAll(skip: (page - 1) * take, take: take)
                .Select(x => _mapper.Map<AuthorItemDto>(x))
            .ToListAsync();
            return categories;

        }

        public async Task<GetAuthorDto> GetByIdAsync(int id)
        {
            Author author = await _authorRepository.GetByIdAsync(id, nameof(Author.Blogs));
            if (author == null) return null;
            var authorDto = _mapper.Map<GetAuthorDto>(author);
            return authorDto;
        }
        public async Task CreateAsync(CreateAuthorDto authorDto)
        {
            if (await _authorRepository.AnyAsync(c => c.Name == authorDto.Name))
                throw new Exception("Author exist");

            var author = _mapper.Map<Author>(authorDto);

            author.CreatedAt = DateTime.Now;
            author.UpdatedAt = DateTime.Now;

            await _authorRepository.AddAsync(author);
            await _authorRepository.SaveChangesAsync();
        }

        public async Task UpdateAuthorAsync(int id, UpdateAuthorDto authorDto)
        {
            Author author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
                throw new Exception("Not found");

            //if (await _authorRepository.AnyAsync(c => c.Name == authorDto.Name && c.Id != id ))
            //    throw new Exception("Exists");
            _mapper.Map(authorDto, author);
            author.UpdatedAt = DateTime.Now;

            // author = _mapper.Map<Author>(authorDto);
            _authorRepository.Update(author);
            await _authorRepository.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(int id)
        {
            Author author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
                throw new Exception("Not found");

            _authorRepository.Delete(author);
            await _authorRepository.SaveChangesAsync();
        }

    }
}
