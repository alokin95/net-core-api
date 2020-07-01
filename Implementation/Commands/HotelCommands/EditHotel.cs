using Application.Commands.HotelCommands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var hotel = this.context.Hotels.Find(dto.Id);

            if (hotel == null)
            {
                throw new EntityNotFoundException(dto.Id);
            }

            var location = this.context.Locations.Find(hotel.LocationId);
            dto.Location.Id = location.Id;

            this.mapper.Map(dto, hotel);
            this.mapper.Map(dto.Location, location);

            this.context.SaveChanges();
        }
    }
}
