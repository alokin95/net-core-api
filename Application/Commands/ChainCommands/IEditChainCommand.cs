﻿using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ChainCommands
{
    public interface IEditChainCommand : ICommand<CreateChainDto>
    {
    }
}
