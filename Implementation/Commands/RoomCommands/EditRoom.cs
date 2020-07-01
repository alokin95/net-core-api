using Application.Commands.RoomCommands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validations;
using System;
using System.Collections.Generic;
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

            var room = this.context.Rooms.Find(dto.Id);

            if (room == null)
            {
                throw new EntityNotFoundException(dto.Id);
            }

            this.mapper.Map(dto, room);

            this.context.SaveChanges();
        }
    }
}
