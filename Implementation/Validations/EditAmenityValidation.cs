using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Implementation.Validations
{
    public class EditAmenityValidation : AbstractValidator<AmenityDto>
    {
        private readonly Database context;
        public EditAmenityValidation(Database context)
        {
            this.context = context;

            RuleFor(dto => dto.Name)
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(100)
                .Must(NameMustBeUnique)
                .WithMessage("The selected name already exists");

            RuleFor(dto => dto.Description)
                .NotNull()
                .MinimumLength(2);
        }

        private bool NameMustBeUnique(AmenityDto dto, string name)
        {
            return !this.context.Amenities.Any(c => c.Name.ToLower() == name && c.Id != dto.Id);
        }
    }
}
