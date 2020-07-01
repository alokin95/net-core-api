using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.HotelQueries;
using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.HotelQueries
{
    public class GetOneHotel : IGetSingleHotelQuery
    {
        public int Id => 15;

        public string Name => "Fetch single hotel";

        private readonly Database context;
        private readonly IMapper mapper;

        public GetOneHotel(Database context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public HotelDto Execute(int id)
        {
            var hotel = this.context.Hotels
                .Include(h => h.Location)
                .Include(h => h.Rooms)
                .Include(h => h.Amenities)
                    .ThenInclude(ha => ha.Amenity)
                .FirstOrDefault(h => h.Id == id);

            if (hotel == null)
            {
                throw new EntityNotFoundException(id);
            }

            var hotelResponse = this.mapper.Map<HotelDto>(hotel);

            Console.WriteLine("sadad");
            return hotelResponse;
        }
    }
}
