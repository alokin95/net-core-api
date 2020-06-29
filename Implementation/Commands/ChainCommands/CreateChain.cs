using Application.Commands.ChainCommands;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domain.Entity;
using FluentValidation;
using Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries.ChainCommands
{
    public class CreateChain : ICreateChainCommand
    {
        public int Id => 4;

        public string Name => "Create a chain";

        private readonly Database context;
        private readonly IMapper mapper;
        private readonly CreateChainValidation createChainValidator;

        public CreateChain(Database context, IMapper mapper, CreateChainValidation validations)
        {
            this.context = context;
            this.mapper = mapper;
            this.createChainValidator = validations;
        }

        public void Execute(CreateChainDto createChainDto)
        {
            this.createChainValidator.ValidateAndThrow(createChainDto);

            var chain = mapper.Map<Chain>(createChainDto);

            this.context.Chains.Add(chain);
            this.context.SaveChanges();
        }
    }
}
