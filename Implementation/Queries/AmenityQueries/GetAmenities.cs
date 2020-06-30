using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Queries.AmenityQueries;
using Application.Response;
using AutoMapper;
using DataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.AmenityQueries
{
    public class GetAmenities : IGetAmenitiesQuery
    {
        public int Id => 10;

        public string Name => "Get amenities";

        private readonly Database context;
        private readonly IMapper mapper;

        public GetAmenities(Database context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PagedResponse<AmenityDto> Execute(AmenitySearch amenitySearch)
        {
            var amenitiesQuery = this.context.Amenities.AsQueryable();

            if(amenitySearch.Name != null)
            {
                amenitiesQuery = amenitiesQuery.Where(a => a.Name.ToLower().Contains(amenitySearch.Name.ToLower()));
            }

            if (amenitySearch.Description != null)
            {
                amenitiesQuery = amenitiesQuery.Where(a => a.Description.ToLower().Contains(amenitySearch.Description.ToLower()));
            }

            var amenities = this.mapper.Map<List<AmenityDto>>(amenitiesQuery.FormatForPagedResponse(amenitySearch));

            return amenities.GeneratePagedResponse(amenitySearch, amenitiesQuery);
        }
    }
}
