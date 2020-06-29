using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.HotelCommands
{
    public interface ICreateHotelCommand : ICommand<HotelDto>
    {
    }
}
