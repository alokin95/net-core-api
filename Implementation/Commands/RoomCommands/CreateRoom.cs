using Application.Commands.RoomCommands;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domain.Entity;
using FluentValidation;
using Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.RoomCommands
{
    public class CreateRoom : ICreateRoomCommand
    {
        public int Id =>18;

        public string Name => "Create a room";

        private readonly Database context;
        private readonly IMapper mapper;
        private readonly CreateRoomValidation createRoomValidation;

        public CreateRoom(IMapper mapper, CreateRoomValidation createRoomValidation, Database context)
        {
            this.mapper = mapper;
            this.createRoomValidation = createRoomValidation;
            this.context = context;
        }

        public void Execute(CreateRoomDto dto)
        {
            this.createRoomValidation.ValidateAndThrow(dto);

            var room = this.mapper.Map<Room>(dto);

            this.context.Rooms.Add(room);
            this.context.SaveChanges();
        }
    }
}
