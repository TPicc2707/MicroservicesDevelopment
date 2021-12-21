using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.People.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommandVm>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{FirstName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{FirstName} must not exceed 50 characters");

            RuleFor(p => p.MiddleInitial)
                .MaximumLength(1).WithMessage("{MiddleInitial} must not exceed 1 characters");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{LastName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{LastName} must not exceed 50 characters");

            RuleFor(p => p.Title)
                .MaximumLength(5).WithMessage("{Title} must not exceed 5 characters");

            RuleFor(p => p.Rank)
                .NotEmpty().WithMessage("{Rank} is required.")
                .NotNull()
                .MaximumLength(10).WithMessage("{Rank} must not exceed 10 characters");

            RuleFor(p => p.Gender)
                .NotEmpty().WithMessage("{Gender} is required.")
                .NotNull()
                .MaximumLength(6).WithMessage("{Gender} must not exceed 6 characters");

            RuleFor(p => p.EyeColor)
                .NotEmpty().WithMessage("{EyeColor} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{EyeColor} must not exceed 20 characters");

            RuleFor(p => p.Race)
                .NotEmpty().WithMessage("{Race} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{Race} must not exceed 20 characters");

            RuleFor(p => p.Weight)
                .NotEmpty().WithMessage("{Weight} is required.")
                .GreaterThan(0).WithMessage("{Weight} should be greater than zero.");

            RuleFor(p => p.Height)
                .NotEmpty().WithMessage("{Height} is required.")
                .GreaterThan(0).WithMessage("{Height} should be greater than zero.");

        }
    }
}
