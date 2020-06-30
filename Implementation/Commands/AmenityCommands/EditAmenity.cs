using Application.Commands.AmenityCommands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using Domain.Entity;
using FluentValidation;
using Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.AmenityCommands
{
    public class EditAmenity : IEditAmenityCommand
    {
        public int Id => 14;

        public string Name => "Edit amenity";

        private readonly Database context;
        private readonly EditAmenityValidation editAmenityValidation;
        private readonly IMapper mapper;

        public EditAmenity(Database context, EditAmenityValidation editAmenityValidation, IMapper mapper)
        {
            this.context = context;
            this.editAmenityValidation = editAmenityValidation;
            this.mapper = mapper;
        }

        public void Execute(AmenityDto dto)
        {
            this.editAmenityValidation.ValidateAndThrow(dto);

            var amenity = this.context.Amenities.Find(dto.Id);

            if (amenity == null)
            {
                throw new EntityNotFoundException(dto.Id);
            }

            this.mapper.Map(dto, amenity);

            this.context.SaveChanges();
        }
    }
}
