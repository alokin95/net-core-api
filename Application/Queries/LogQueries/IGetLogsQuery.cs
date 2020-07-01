using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.LogQueries
{
    public interface IGetLogsQuery : IQuery<LogSearch, PagedResponse<LogDto>>
    {
    }
}
