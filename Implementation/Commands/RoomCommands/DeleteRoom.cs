using Application.Commands.RoomCommands;
using Application.Exceptions;
using DataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.RoomCommands
{
    public class DeleteRoom : IDeleteRoomCommand
    {
        public int Id => 23;

        public string Name => "Delete a room";

        private readonly Database context;

        public DeleteRoom(Database context)
        {
            this.context = context;
        }

        public void Execute(int id)
        {
            var room = this.context.Rooms.Find(id);

            if (room == null)
            {
                throw new EntityNotFoundException(id);
            }

            room.Delete();
            this.context.SaveChanges();
        }
    }
}
