using Application.DataTransfer;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<ApplicationLog, LogDto>();
            CreateMap<LogDto, ApplicationLog>();
        }
    }
}
