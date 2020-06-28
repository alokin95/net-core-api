using Application;
using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Queries.Chain;
using Application.Response;
using AutoMapper;
using DataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.Chain
{
    public class GetChains : IGetChainsQuery
    {
        public int Id => 2;

        public string Name => "Get all chains";

        private readonly IMapper mapper;
        private readonly Database context;

        public GetChains(IMapper mapper, Database context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public PagedResponse<ChainDto> Execute(ChainSearch chainSearch)
        {
            var chainsQuery = this.context.Chains.AsQueryable();

            if (chainSearch.Name != null)
            {
                chainsQuery = chainsQuery.Where(c => c.Name.ToLower().Contains(chainSearch.Name.ToLower()));
            }

            var chains = mapper.Map<List<ChainDto>>(chainsQuery.FormatForPagedResponse(chainSearch));
            
            return chains.GeneratePagedResponse(chainSearch, chainsQuery);
        }

    }
}
