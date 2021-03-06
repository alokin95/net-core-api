﻿using Application.DataTransfer;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class RoomAmenityProfile : Profile
    {
        public RoomAmenityProfile()
        {
            CreateMap<RoomAmenityDto, RoomAmenity>();
            CreateMap<RoomAmenity, RoomAmenityDto>();
        }
    }
}
