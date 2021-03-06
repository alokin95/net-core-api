﻿using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Implementation.Validations
{
    public class CreateLocationValidation : AbstractValidator<LocationDto>
    {
        public CreateLocationValidation(Database _context)
        {
            RuleFor(l => l.Country)
                .NotEmpty()
                .MinimumLength(2);
            
            RuleFor(l => l.City)
                .NotEmpty()
                .MinimumLength(2);
            
            RuleFor(l => l.Address)
                .NotEmpty()
                .MinimumLength(2)
                .Must((dto, postalCode) => !_context.Locations.Any(l => l.PostalCode == dto.PostalCode && l.City == dto.City && l.Address == dto.Address && l.Country == dto.Country))
                .WithMessage("The specified address is already tied to a hotel. Please check the credentials or contact us");
            
            RuleFor(l => l.PostalCode)
                .NotEmpty();
        }


    }
}
