using API.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validations
{
    public class CreateHotelValidator : AbstractValidator<HotelDto>
    {
        private readonly Database _dbContext;
        public CreateHotelValidator(Database context)
        {
            _dbContext = context;

            RuleFor(dto => dto.Name)
                .NotEmpty()
                .WithMessage("The name field is required");
        }
    }
}
