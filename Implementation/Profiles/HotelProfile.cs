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
                .ForMember(dto => dto.Location, opt => opt.MapFrom(h => new LocationDto
                {
                    Address = h.Location.Address,
                    City = h.Location.City,
                    PostalCode = h.Location.PostalCode,
                    Country = h.Location.Country
                }));
            CreateMap<HotelDto, Hotel>();
        }
    }
}
