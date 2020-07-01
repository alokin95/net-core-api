using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.UserQueries
{
    public interface IGetUsersQuery : IQuery<UserSearch, PagedResponse<UserDto>>
    {
    }
}
