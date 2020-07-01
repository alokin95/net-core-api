using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.RoomQueries;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries.RoomQueries
{
    public class GetOneRoom : IGetSingleRoomQuery
    {
        public int Id => 21;

        public string Name => "Get single room";

        private readonly Database context;
        private readonly IMapper mapper;

        public GetOneRoom(Database context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public RoomDto Execute(int id)
        {
            var room = this.context.Rooms.Find(id);

            if (room == null)
            {
                throw new EntityNotFoundException(id);
            }

            return this.mapper.Map<RoomDto>(room);
        }
    }
}
