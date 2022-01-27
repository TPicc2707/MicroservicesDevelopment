using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.PeopleAddress.Commands.CreatePersonAddress
{
    public class CreatePersonAddressValidator : AbstractValidator<CreatePersonAddressCommandVm>
    {
        public CreatePersonAddressValidator()
        {
            RuleFor(p => p.Person_Id)
                .NotEmpty().WithMessage("{Person_Id} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{Person_Id} should be greater than zero.");

            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("{Type} is required.")
                .NotNull()
                .MaximumLength(10).WithMessage("{Type} must not exceed 10 characters");

            RuleFor(p => p.Street)
                .NotEmpty().WithMessage("{Street} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Street} must not exceed 50 characters");

            RuleFor(p => p.City)
                .NotEmpty().WithMessage("{City} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{City} must not exceed 50 characters");

            RuleFor(p => p.State)
                .NotEmpty().WithMessage("{State} is required.")
                .NotNull()
                .MaximumLength(2).WithMessage("{State} must not exceed 2 characters");

            RuleFor(p => p.ZipCode)
                .NotEmpty().WithMessage("{ZipCode} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{ZipCode} should be greater than zero.")
                .LessThan(100000).WithMessage("{ZipCode} should be less than 100000");


        }

    }
}
