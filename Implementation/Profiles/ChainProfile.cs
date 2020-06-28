using Application.DataTransfer;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class ChainProfile : Profile
    {
        public ChainProfile()
        {
            CreateMap<Chain, ChainDto>();
            CreateMap<ChainDto, Chain>();
        }
    }
}
