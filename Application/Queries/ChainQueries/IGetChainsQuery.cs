using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.ChainQueries
{
    public interface IGetChainsQuery : IQuery<ChainSearch, PagedResponse<ChainDto>>
    {
    }
}
