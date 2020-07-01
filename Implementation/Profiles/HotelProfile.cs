using Application.DataTransfer;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDto>()
                .ForMember(dto => dto.Amenities,
                opt => opt.MapFrom(hotel => hotel.Amenities.Select(ha => new AmenityDto
                {
                    Description = ha.Amenity.Description,
                    Icon = ha.Amenity.Icon,
                    Name = ha.Amenity.Name
                })));
            CreateMap<HotelDto, Hotel>();
        }
    }
}
