using Application;
using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Queries.ChainQueries;
using Application.Response;
using AutoMapper;
using DataAccess;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.ChainQueries
{
    public class GetChains : IGetChainsQuery
    {

        public int Id => 2;

        public string Name => "Get all chains";

        protected readonly IMapper mapper;
        protected readonly Database context;
        public GetChains(Database context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PagedResponse<ChainDto> Execute(ChainSearch chainSearch)
        {
            var chainsQuery = this.context.Chains
                .Include(c => c.Manager)
                .AsQueryable();

            if (chainSearch.Name != null)
            {
                chainsQuery = chainsQuery.Where(c => c.Name.ToLower().Contains(chainSearch.Name.ToLower()));
            }

            if (chainSearch.Firstname != null)
            {
                chainsQuery = chainsQuery.Where(c => c.Manager.FirstName.ToLower().Contains(chainSearch.Firstname.ToLower()));
            }

            if (chainSearch.Lastname != null)
            {
                chainsQuery = chainsQuery.Where(c => c.Manager.LastName.ToLower().Contains(chainSearch.Lastname.ToLower()));
            }

            var chains = mapper.Map<List<ChainDto>>(chainsQuery.FormatForPagedResponse(chainSearch));
            
            return chains.GeneratePagedResponse(chainSearch, chainsQuery);
        }

    }
}
