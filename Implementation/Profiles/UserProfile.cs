using Application.DataTransfer;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
