using Application.Commands.HotelCommands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using Domain.Entity;
using FluentValidation;
using Implementation.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Implementation.Commands.HotelCommands
{
    public class EditHotel : IEditHotelCommand
    {
        public int Id => 16;

        public string Name => "Edit a hotel";

        private readonly Database context;
        private readonly IMapper mapper;
        private readonly EditHotelValidation editHotelValidation;

        public EditHotel(Database context, IMapper mapper, EditHotelValidation editHotelValidation)
        {
            this.context = context;
            this.mapper = mapper;
            this.editHotelValidation = editHotelValidation;
        }

        public void Execute(CreateHotelDto dto)
        {
            this.editHotelValidation.ValidateAndThrow(dto);

            var hotel = this.context.Hotels
                .Include(h => h.Location)
                .Include(h => h.Amenities)
                .FirstOrDefault(h => h.Id == dto.Id);

            if (hotel == null)
            {
                throw new EntityNotFoundException(dto.Id);
            };

            hotel.Amenities.Where(amenities => amenities.HotelId == hotel.Id)
                .ToList()
                .ForEach(amenity => hotel.Amenities.Remove(amenity));

            foreach (var amenity in dto.Amenities)
            {
                hotel.Amenities.Add(new HotelAmenity
                {
                    AmenityId = amenity.AmenityId,
                    HotelId = hotel.Id
                });
            }
            
            dto.Location.Id = hotel.LocationId;

            this.mapper.Map(dto, hotel);
            this.mapper.Map(dto.Location, hotel.Location);

            this.context.SaveChanges();
        }
    }
}
