using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validations
{
    public class CreateRoomValidation : AbstractValidator<CreateRoomDto>
    {
        private readonly Database context;
        public CreateRoomValidation(Database context)
        {
            this.context = context;

            RuleFor(r => r.Description)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200);

            RuleFor(r => r.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100)
                .Must(NameMustBeUniqueForEachHotel)
                .WithMessage("This type of room is already created");

            RuleFor(r => r.HotelId)
                .NotEmpty()
                .Must(HotelMustExist)
                .WithMessage("The selected hotel does not exist");
        }

        private bool HotelMustExist(int hotelId)
        {
            return this.context.Hotels.Any(h => h.Id == hotelId);
        }

        private bool NameMustBeUniqueForEachHotel(CreateRoomDto dto, string name)
        {
            return !this.context.Rooms.Any(room => room.Name.ToLower() == name.ToLower() && room.HotelId == dto.HotelId);
        }
    }
}
