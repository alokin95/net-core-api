using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.Chain;
using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.ChainQueries
{
    public class GetOneChain : IGetSingleChainQuery
    {
        public int Id => 3;

        public string Name => "Get single chain";

        private readonly Database context;
        private readonly IMapper mapper;

        public GetOneChain(Database context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ChainDto Execute(int id)
        {
            var chain = this.context.Chains
                .Include(c => c.Manager)
                .Include(c => c.Hotels)
                    .ThenInclude(h => h.Location)
                .FirstOrDefault(c => c.Id == id);

            if (chain == null)
            {
                throw new EntityNotFoundException(id);
            }

            return this.mapper.Map<ChainDto>(chain);
        }
    }
}
