using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validations
{
    public class RoomAmenityValidation : AbstractValidator<RoomAmenityDto>
    {
        private readonly Database context;
        public RoomAmenityValidation(Database context)
        {
            this.context = context;

            RuleFor(dto => dto.AmenityId)
                .Must(AmenityMustExist)
                .WithMessage("The selected amenity does not exist");

            RuleFor(dto => dto.RoomId)
                .Must(RoomMustExist)
                .WithMessage("The selected room does not exist");

            RuleFor(dto => dto.AmenityId)
                .Must(PairMustBeUnique)
                .WithMessage("Please pick another amenity");
        }

        private bool PairMustBeUnique(RoomAmenityDto dto, int id)
        {
            var amenity = this.context.Amenities.Find(id);

            if (amenity == null)
            {
                return false;
            }

            var room = this.context.Rooms.Find(dto.RoomId);

            if (room == null)
            {
                return false;
            }

            if (room.Amenities.Any(a => a.AmenityId == id))
            {
                return false;
            }

            return true;
        }

        private bool RoomMustExist(int id)
        {
            return this.context.Rooms.Any(a => a.Id == id);
        }

        private bool AmenityMustExist(int id)
        {
            return this.context.Amenities.Any(a => a.Id == id);
        }
    }
}
