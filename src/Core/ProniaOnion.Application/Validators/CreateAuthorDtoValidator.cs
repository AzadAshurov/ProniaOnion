using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.DTOs.Authors;

namespace ProniaOnion.Application.Validators
{
    public class CreateAuthorDtoValidator : AbstractValidator<CreateAuthorDto>
    {
        private readonly IAuthorRepository _repository;

        public CreateAuthorDtoValidator(IAuthorRepository repository)
        {
            _repository = repository;
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Data required")
                .MaximumLength(100).WithMessage("Characters should be less than 100")
                .Matches(@"^[A-Za-z\s0-9]*$");
            RuleFor(c => c.Surname)
                .NotEmpty().WithMessage("Data required")
                .MaximumLength(100).WithMessage("Characters should be less than 100")
                .Matches(@"^[A-Za-z\s0-9]*$");
        }
    }
}
