using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validations
{
    public class EditRoomValidation : AbstractValidator<CreateRoomDto>
    {
        private readonly Database context;
        public EditRoomValidation(Database context)
        {
            this.context = context;

            RuleFor(r => r.Description)
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(200);

            RuleFor(r => r.Name)
                .NotNull()
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
            return !this.context.Rooms.Any(room => room.Name.ToLower() == name.ToLower() && room.HotelId == dto.HotelId && room.Id != dto.Id);
        }
    }
}
