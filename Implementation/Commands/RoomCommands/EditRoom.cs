using Application.Commands.RoomCommands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using Domain.Entity;
using FluentValidation;
using Implementation.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.RoomCommands
{
    public class EditRoom : IEditRoomCommand
    {
        public int Id => 22;
        public string Name =>"Edit room";

        private readonly Database context;
        private readonly EditRoomValidation editRoomValidation;
        private readonly IMapper mapper;

        public EditRoom(Database context, EditRoomValidation editRoomValidation, IMapper mapper)
        {
            this.context = context;
            this.editRoomValidation = editRoomValidation;
            this.mapper = mapper;
        }

        public void Execute(CreateRoomDto dto)
        {
            this.editRoomValidation.ValidateAndThrow(dto);

            var room = this.context.Rooms
                .Include(r => r.Amenities)
                .FirstOrDefault(r => r.Id == dto.Id);

            if (room == null)
            {
                throw new EntityNotFoundException(dto.Id);
            }

            room.Amenities.Where(amenities => amenities.RoomId == room.Id)
                .ToList()
                .ForEach(amenity => room.Amenities.Remove(amenity));

            foreach (var amenity in dto.Amenities)
            {
                room.Amenities.Add(new RoomAmenity
                {
                    AmenityId = amenity.AmenityId,
                    RoomId = room.Id
                });
            }

            this.mapper.Map(dto, room);

            this.context.SaveChanges();
        }
    }
}
