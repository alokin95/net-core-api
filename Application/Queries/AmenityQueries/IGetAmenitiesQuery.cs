using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.AmenityQueries
{
    public interface IGetAmenitiesQuery : IQuery<AmenitySearch, PagedResponse<AmenityDto>>
    {
    }
}
