using Application.DataTransfer;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    class CreateChainProfile : Profile
    {
        public CreateChainProfile()
        {
            CreateMap<CreateChainDto, Chain>();
        }
    }
}
