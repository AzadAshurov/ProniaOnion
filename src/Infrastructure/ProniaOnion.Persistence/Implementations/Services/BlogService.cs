using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Blogs;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class BlogService : IBlogService

    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BlogItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<BlogItemDto> categories = await _blogRepository.GetAll(skip: (page - 1) * take, take: take)
                .Select(x => _mapper.Map<BlogItemDto>(x))
            .ToListAsync();
            return categories;

        }

        public async Task<GetBlogDto> GetByIdAsync(int id)
        {
            Blog blog = await _blogRepository.GetByIdAsync(id, "blog => blog.Tags.Where(op => op.blogId == blog.Id).Select(p => p.Tag)");
            if (blog == null) return null;
            var blogDto = _mapper.Map<GetBlogDto>(blog);
            return blogDto;
        }
        public async Task CreateAsync(CreateBlogDto blogDto)
        {
            //if (await _blogRepository.AnyAsync(c => c.Name == blogDto.Name))
            //    throw new Exception("Blog exist");

            var blog = _mapper.Map<Blog>(blogDto);

            blog.CreatedAt = DateTime.Now;
            blog.UpdatedAt = DateTime.Now;

            await _blogRepository.AddAsync(blog);
            await _blogRepository.SaveChangesAsync();
        }

        public async Task UpdateBlogAsync(int id, UpdateBlogDto blogDto)
        {
            Blog blog = await _blogRepository.GetByIdAsync(id);
            if (blog == null)
                throw new Exception("Not found");

            //if (await _blogRepository.AnyAsync(c => c.Name == blogDto.Name && c.Id != id))
            //    throw new Exception("Exists");
            _mapper.Map(blogDto, blog);
            blog.UpdatedAt = DateTime.Now;

            // blog = _mapper.Map<Blog>(blogDto);
            _blogRepository.Update(blog);
            await _blogRepository.SaveChangesAsync();
        }

        public async Task DeleteBlogAsync(int id)
        {
            Blog blog = await _blogRepository.GetByIdAsync(id);

            if (blog == null)
                throw new Exception("Not found");

            _blogRepository.Delete(blog);
            await _blogRepository.SaveChangesAsync();
        }

    }
}
