using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Implementation.Validations
{
    public class CreateLocationValidator : AbstractValidator<LocationDto>
    {
        public CreateLocationValidator(Database _context)
        {
            RuleFor(l => l.Country)
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(l => l.City)
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(l => l.Address)
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(l => l.PostalCode)
                .NotEmpty();
            RuleFor(l => l.Address)
                .Must((dto, postalCode) => !_context.Locations.Any(l => l.Address == dto.Address && l.City == dto.City && l.Country == dto.Country && l.PostalCode == dto.PostalCode))
                .WithMessage("The specified address is already tied to a hotel. Please check the credentials or contact us");
            
        }
    }
}
