using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.UserQueries
{
    public interface IGetSingleUserQuery : IQuery<int, UserDto>
    {
    }
}
