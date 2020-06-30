using Application.DataTransfer;
using DataAccess;
using Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validations
{
    public class CreateAmenityValidation : AbstractValidator<AmenityDto>
    {
        private readonly Database context;
        public CreateAmenityValidation(Database context)
        {
            this.context = context;

            RuleFor(dto => dto.Description)
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(100);

            RuleFor(dto => dto.Name)
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(100)
                .Must(NameMustBeUnique)
                .WithMessage("The selected name already exists. Please try another");
        }

        private bool NameMustBeUnique(string name)
        {
            return !this.context.Amenities.Any(c => c.Name == name);
        }
    }
}
