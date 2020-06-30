using Application.Commands.AmenityCommands;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domain.Entity;
using FluentValidation;
using Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.AmmenityCommands
{
    public class CreateAmenity : ICreateAmenityCommand
    {
        public int Id => 11;

        public string Name => "Create amenity";

        private readonly Database context;
        private readonly CreateAmenityValidation createAmenityValidation;
        private readonly IMapper mapper;

        public CreateAmenity(Database context, CreateAmenityValidation createAmenityValidation, IMapper mapper)
        {
            this.context = context;
            this.createAmenityValidation = createAmenityValidation;
            this.mapper = mapper;
        }

        public void Execute(AmenityDto dto)
        {
            this.createAmenityValidation.ValidateAndThrow(dto);

            var amenity = this.mapper.Map<Amenity>(dto);

            this.context.Amenities.Add(amenity);
            this.context.SaveChanges();
        }
    }
}
