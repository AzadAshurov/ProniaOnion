
using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.DTOs.Sizes;

namespace ProniaOnion.Application.Validators
{
    public class CreateSizeDtoValidator : AbstractValidator<CreateSizeDto>
    {
        private readonly ISizeRepository _repository;

        public CreateSizeDtoValidator(ISizeRepository repository)
        {
            _repository = repository;
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Data required")
                .MaximumLength(100).WithMessage("Characters should be less than 100")
                .Matches(@"^[A-Za-z\s0-9]*$");
        }
    }
}
