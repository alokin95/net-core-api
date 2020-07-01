using Application.DataTransfer;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class CreateRoomProfile : Profile
    {
        public CreateRoomProfile()
        {
            CreateMap<Room, CreateRoomDto>();
            CreateMap<CreateRoomDto, Room>();
        }
    }
}
