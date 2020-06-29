using Application.DataTransfer;
using Application.DataTransfer.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Chain
{
    public interface IGetSingleChainQuery : IQuery<int, ChainDto>
    {
    }
}
