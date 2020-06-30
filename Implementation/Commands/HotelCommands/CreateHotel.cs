using Application.Commands.HotelCommands;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.HotelCommands
{
    public class CreateHotel : ICreateHotelCommand
    {
        public int Id => 15;
        public string Name => "Create a hotel";

        private readonly Database context;
        private readonly IMapper mapper;
        private readonly CreateHotelValidation createHotelValidation;

        public CreateHotel(Database context, IMapper mapper, CreateHotelValidation createHotelValidation)
        {
            this.context = context;
            this.mapper = mapper;
            this.createHotelValidation = createHotelValidation;
        }

        public void Execute(HotelDto request)
        {
            throw new NotImplementedException();
        }
    }
}
