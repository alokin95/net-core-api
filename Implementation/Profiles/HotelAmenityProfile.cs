using Application.DataTransfer;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class HotelAmenityProfile : Profile
    {
        public HotelAmenityProfile()
        {
            CreateMap<HotelAmenityDto, HotelAmenity>();
            CreateMap<HotelAmenity, HotelAmenityDto>();
        }
    }
}
