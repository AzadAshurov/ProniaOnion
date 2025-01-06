using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.DTOs.Blogs;

namespace ProniaOnion.Application.Validators
{
    public class CreateBlogDtoValidator : AbstractValidator<CreateBlogDto>
    {
        private readonly IBlogRepository _repository;

        public CreateBlogDtoValidator(IBlogRepository repository)
        {
            _repository = repository;
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Data required")
                .MaximumLength(100).WithMessage("Characters should be less than 100")
                .Matches(@"^[A-Za-z\s0-9]*$");
            RuleFor(c => c.Article)
                .NotEmpty().WithMessage("Data required")
                .MaximumLength(100).WithMessage("Characters should be less than 100")
                .Matches(@"^[A-Za-z\s0-9]*$");
        }
    }
}
