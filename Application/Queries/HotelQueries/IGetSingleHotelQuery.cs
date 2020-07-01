using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.HotelQueries
{
    public interface IGetSingleHotelQuery : IQuery<int, HotelDto>
    {
    }
}
