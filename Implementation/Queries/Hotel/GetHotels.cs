using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Hotel.Queries;
using Application.Queries;
using Application.Response;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Hotel
{
    public class GetHotels : IGetHotelsQuery
    {
        private readonly Database dbContext;
        private readonly IMapper mapper;

        public GetHotels(Database dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public string Name => "List all hotels";

        public int Id => 1;

        public PagedResponse<HotelDto> Execute(HotelSearch search)
        {
            var hotelsQuery = this.dbContext.Hotels.AsQueryable();

            var skipCount = search.PerPage * (search.Page - 1);

            var hotels = mapper.Map<List<HotelDto>>(hotelsQuery.Skip(skipCount).Take(search.Page).ToList());

            var response = new PagedResponse<HotelDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                Total = hotels.Count(),
                Items = hotels
            };

            return response;
        }
    }
}
