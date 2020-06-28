using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Implementation.Validations
{
    public class EditHotelValidator : AbstractValidator<HotelDto>
    {
        private readonly Database _context;
        public EditHotelValidator(Database context)
        {
            _context = context;

            RuleFor(h => h.Name)
                .NotEmpty()
                .Must((dto, name) => !_context.Hotels.Any(h => h.Name == name && h.Id != dto.Id));
        }
    }
}
