using API.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validations
{
    public class EditLocationValidator : AbstractValidator<LocationDto>
    {
        public EditLocationValidator(Database database)
        {
            RuleFor(l => l.City)
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(l => l.Country)
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(l => l.Address)
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(l => l.PostalCode)
                .NotEmpty()
                .Must((dto, postalCode) => !database.Locations.Any(l => l.PostalCode == dto.PostalCode
                && l.Country == dto.Country
                && l.City == dto.City
                && l.Id != dto.Id))
                .WithMessage("The same address already exists. Please enter another one");

        }
    }
}
