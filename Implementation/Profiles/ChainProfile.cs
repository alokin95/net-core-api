using Application.DataTransfer;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Profiles
{
    public class ChainProfile : Profile
    {
        public ChainProfile()
        {
            CreateMap<Chain, ChainDto>()
                .ForMember(dto => dto.Hotels,
                opt => opt.MapFrom(chain => chain.Hotels.Select(h => new HotelDto
                {
                    Name = h.Name,
                    Description = h.Description,
                    Id = h.Id
                })))
                .ForMember(dto => dto.Manager,
                opt => opt.MapFrom(chain => new UserDto
                {
                    Email = chain.Manager.Email,
                    Firstname = chain.Manager.FirstName,
                    Lastname = chain.Manager.LastName
                }));
            CreateMap<ChainDto, Chain>();
        }
    }
}
