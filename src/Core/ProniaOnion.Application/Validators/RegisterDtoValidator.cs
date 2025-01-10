using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProniaOnion.Domain.Entities.Identity;

namespace ProniaOnion.Application.Validators
{
    public class RegisterDtoValidator : AbstractValidator<AppUser>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[A-Za-z]+$");

            RuleFor(r => r.Surname)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[A-Za-z]+$");

            RuleFor(r => r.UserName)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(256)
                .Matches(@"^[A-Za-z0-9_.-]+$");

            RuleFor(r => r.Email)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(256)
                .Matches(@"^[\w.\-]+@([\w\-]+\.)+[\w]{2,3}$");

            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(100);
        }
    }
}
