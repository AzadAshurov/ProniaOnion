
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Genres;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class GenreService : IGenreService

    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<GenreItemDto> genres = await _genreRepository.GetAll(skip: (page - 1) * take, take: take)
                .Select(x => _mapper.Map<GenreItemDto>(x))
            .ToListAsync();
            return genres;

        }

        public async Task<GetGenreDto> GetByIdAsync(int id)
        {
            Genre genre = await _genreRepository.GetByIdAsync(id, nameof(Genre.Blogs));

            if (genre == null) return null;
            var genreDto = _mapper.Map<GetGenreDto>(genre);
       

            return genreDto;
        }
        public async Task CreateAsync(CreateGenreDto genreDto)
        {
            if (await _genreRepository.AnyAsync(c => c.Name == genreDto.Name))
                throw new Exception("Genre exist");

            var genre = _mapper.Map<Genre>(genreDto);

            genre.CreatedAt = DateTime.Now;
            genre.UpdatedAt = DateTime.Now;

            await _genreRepository.AddAsync(genre);
            await _genreRepository.SaveChangesAsync();
        }

        public async Task UpdateGenreAsync(int id, UpdateGenreDto genreDto)
        {
            Genre genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
                throw new Exception("Not found");

            if (await _genreRepository.AnyAsync(c => c.Name == genreDto.Name && c.Id != id))
                throw new Exception("Exists");
            _mapper.Map(genreDto, genre);
            genre.UpdatedAt = DateTime.Now;
            // genre = _mapper.Map<Genre>(genreDto);
            genre.Id = id;
            _genreRepository.Update(genre);
            await _genreRepository.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(int id)
        {
            Genre genre = await _genreRepository.GetByIdAsync(id);

            if (genre == null)
                throw new Exception("Not found");

            _genreRepository.Delete(genre);
            await _genreRepository.SaveChangesAsync();
        }

    }
}
