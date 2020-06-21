using API.DTO;
using AutoMapper;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDto>();
            CreateMap<HotelDto, Hotel>();
        }
    }
}
