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
                    Id = ha.Amenity.Id,
                    Description = ha.Amenity.Description,
                    Icon = ha.Amenity.Icon,
                    Name = ha.Amenity.Name
                })))
                .ForMember(dto => dto.Location,
                opt => opt.MapFrom(hotel => new LocationDto
                {
                    Address = hotel.Location.Address,
                    City = hotel.Location.City,
                    Country = hotel.Location.Country,
                    PostalCode = hotel.Location.PostalCode,
                    Id = hotel.Location.Id
                }))
                .ForMember(dto => dto.Rooms,
                opt => opt.MapFrom(hotel => hotel.Rooms.Select(r => new RoomDto
                {
                    Name = r.Name,
                    Description = r.Description
                })));

            CreateMap<HotelDto, Hotel>();
        }
    }
}
