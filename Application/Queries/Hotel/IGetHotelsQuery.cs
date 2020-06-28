using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Hotel.Queries
{
    public interface IGetHotelsQuery : IQuery<HotelSearch, PagedResponse<HotelDto>>
    {
    }
}
