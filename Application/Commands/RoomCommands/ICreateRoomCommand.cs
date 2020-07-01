using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.RoomCommands
{
    public interface ICreateRoomCommand : ICommand<CreateRoomDto>
    {
    }
}
