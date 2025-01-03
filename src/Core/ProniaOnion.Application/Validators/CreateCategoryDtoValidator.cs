using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.Application.Validators
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryDtoValidator(ICategoryRepository repository)
        {
            _repository = repository;
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine("CreateCategoryDtoValidator created");
            }
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Data required")
                .MaximumLength(100).WithMessage("Characters should be less than 100")
                .Matches(@"^[A-Za-z\s0-9]*$");
            //  .MustAsync(CheckNameExistence);

        }

        //public async Task<bool> CheckNameExistence(string name, CancellationToken token)
        //{
        //    return !await _repository.AnyAsync(c => c.Name == name);
        //}
    }

}
