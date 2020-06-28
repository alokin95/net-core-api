using Application.Commands;
using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class CreateHotel : ICreateHotelCommand
    {
        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public void Execute(HotelDto request)
        {
            throw new NotImplementedException();
        }
    }
}
