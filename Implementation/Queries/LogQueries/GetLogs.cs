using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Queries.LogQueries;
using Application.Response;
using AutoMapper;
using DataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.LogQueries
{
    public class GetLogs : IGetLogsQuery
    {
        public int Id => 30;

        public string Name => "Search logs";

        private readonly Database context;
        private readonly IMapper mapper;

        public GetLogs(Database context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PagedResponse<LogDto> Execute(LogSearch search)
        {
            var logsQuery = this.context.AppLogs.AsQueryable();

            if (search.Actionid != 0)
            {
                logsQuery = logsQuery.Where(lq => lq.Actionid == search.Actionid);
            }

            if (search.UserId != 0)
            {
                logsQuery = logsQuery.Where(lq => lq.UserId == search.UserId);
            }

            if (search.ActorIdentity != null)
            {
                logsQuery = logsQuery.Where(lq => lq.ActorIdentity.ToLower().Contains(search.ActorIdentity.ToLower()));
            }

            if (search.ActionName != null)
            {
                logsQuery = logsQuery.Where(lq => lq.ActionName.ToLower().Contains(search.ActionName.ToLower()));
            }

            var logs = this.mapper.Map<List<LogDto>>(logsQuery.FormatForPagedResponse(search));

            return logs.GeneratePagedResponse(search, logsQuery);
        }
    }
}
