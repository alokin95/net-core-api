using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Hotel.Queries;
using Application.Queries;
using Application.Response;
using AutoMapper;
using DataAccess;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
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
            var hotelsQuery = this.dbContext.Hotels
                .Include(h => h.Location)
                .AsQueryable();

            if (search.Address != null)
            {
                hotelsQuery = hotelsQuery.Where(h => h.Location.Address.ToLower().Contains(search.Address.ToLower()));
            }

            if (search.City != null)
            {
                hotelsQuery = hotelsQuery.Where(h => h.Location.City.ToLower().Contains(search.City.ToLower()));
            }

            if (search.Country != null)
            {
                hotelsQuery = hotelsQuery.Where(h => h.Location.Country.ToLower().Contains(search.Country.ToLower()));
            }

            if (search.PostalCode > 0)
            {
                hotelsQuery = hotelsQuery.Where(h => h.Location.PostalCode == search.PostalCode);
            }

            if (search.Name != null)
            {
                hotelsQuery = hotelsQuery.Where(h => h.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var hotels = this.mapper.Map<List<HotelDto>>(hotelsQuery.FormatForPagedResponse(search));

            return hotels.GeneratePagedResponse(search, hotelsQuery);
        }
    }
}
