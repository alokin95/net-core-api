using Application;
using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Queries.RoomQueries;
using Application.Response;
using AutoMapper;
using DataAccess;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.RoomQueries
{
    public class GetRooms : IGetRoomsQuery
    {
        public int Id => 20;

        public string Name => "Get rooms";

        private readonly Database context;
        private readonly IMapper mapper;

        public GetRooms(Database context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PagedResponse<RoomDto> Execute(RoomSearch search)
        {
            var roomsQuery = this.context.Rooms
                .AsQueryable();

            if (search.HotelId != 0)
            {
                roomsQuery = roomsQuery.Where(r => r.HotelId == search.HotelId);
            }

            var rooms = this.mapper.Map<List<RoomDto>>(roomsQuery.FormatForPagedResponse(search));

            return rooms.GeneratePagedResponse(search, roomsQuery);
        }
    }
}
