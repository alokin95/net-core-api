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
    public class HotelAmenityValidation : AbstractValidator<HotelAmenityDto>
    {
        private readonly Database context;
        public HotelAmenityValidation(Database context)
        {
            this.context = context;

            RuleFor(dto => dto.AmenityId)
                .Must(AmenityMustExist)
                .WithMessage("The selected amenity does not exist");

            RuleFor(dto => dto.HotelId)
                .Must(HotelMustExist)
                .WithMessage("The selected hotel does not exist");

            RuleFor(dto => dto.AmenityId)
                .Must(PairMustBeUnique)
                .WithMessage("Hotel already has that amenity");
        }

        private bool PairMustBeUnique(HotelAmenityDto dto, int id)
        {
            var hotel = this.context.Hotels.Find(dto.HotelId);

            if (hotel.Amenities.Any(a => a.AmenityId == id))
            {
                return false;
            }

            return true;
        }

        private bool HotelMustExist(int id)
        {
            return this.context.Hotels.Any(a => a.Id == id);
        }

        private bool AmenityMustExist(int id)
        {
            return this.context.Amenities.Any(a => a.Id == id);
        }
    }
}
