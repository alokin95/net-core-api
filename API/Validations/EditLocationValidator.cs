using API.DTO;
using API.Errors;
using API.Extensions;
using DataAccess;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validations
{
    public class EditLocationValidator : AbstractValidator<LocationDto>
    {

        private readonly Database _database;
        public EditLocationValidator(Database database)
        {
            _database = database;

            RuleFor(l => l.City)
                .NotEmpty()
            
                .MinimumLength(2);
            RuleFor(l => l.Country)
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(l => l.Address)
                .NotEmpty()
                .MinimumLength(2)
                .Must((dto, postalCode) => !_database.Locations.Any(
                l => l.PostalCode == dto.PostalCode
                && l.Country == dto.Country
                && l.City == dto.City
                && l.Address == dto.Address
                && l.Id != dto.Id))
                .WithMessage("The same address already exists. Please enter another one");;
            RuleFor(l => l.PostalCode)
                .NotEmpty();
                
        }
    }
}
