﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.DTOs.Tags;

namespace ProniaOnion.Application.Validators
{
    public class CreateTagDtoValidator : AbstractValidator<CreateTagDto>
    {
        private readonly ITagRepository _repository;

        public CreateTagDtoValidator(ITagRepository repository)
        {
            _repository = repository;
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Data required")
                .MaximumLength(100).WithMessage("Characters should be less than 100")
                .Matches(@"^[A-Za-z\s0-9]*$");
        }
    }
}
