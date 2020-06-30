using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.AmenityQueries;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.AmenityQueries
{
    public class GetOneAmenity : IGetSingleAmenityQuery
    {
        public int Id => 13;

        public string Name => "Get one amenity";

        private readonly Database context;
        private readonly IMapper mapper;

        public GetOneAmenity(Database context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public AmenityDto Execute(int id)
        {
            var amenity = this.context.Amenities
                .FirstOrDefault(a => a.Id == id);

            if (amenity == null)
            {
                throw new EntityNotFoundException(id);
            }

            return this.mapper.Map<AmenityDto>(amenity);
        }
    }
}
