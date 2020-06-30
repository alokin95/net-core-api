using Application.DataTransfer;
using Application.DataTransfer.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.ChainQueries
{
    public interface IGetSingleChainQuery : IQuery<int, ChainDto>
    {
    }
}
