using Application.DataTransfer;
using AutoMapper;
using Domain.Entity;
using Implementation.Commands.HotelCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class CreateHotelProfile : Profile
    {
        public CreateHotelProfile()
        {
            CreateMap<CreateHotelDto, Hotel>();
            CreateMap<Hotel, CreateHotelDto>();
        }
    }
}
