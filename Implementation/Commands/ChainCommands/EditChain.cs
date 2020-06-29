using Application.Commands.ChainCommands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.ChainCommands
{
    public class EditChain : IEditChainCommand
    {
        public int Id => 7;

        public string Name => "Edit a Chain";

        private readonly Database context;
        private readonly IMapper mapper;
        private readonly EditChainValidation chainValidation;
        public EditChain(Database context, IMapper mapper, EditChainValidation validations)
        {
            this.context = context;
            this.mapper = mapper;
            this.chainValidation = validations;
        }

        public void Execute(CreateChainDto chainDto)
        {
            this.chainValidation.ValidateAndThrow(chainDto);

            var chain = this.context.Chains
                .FirstOrDefault(c => c.Id == chainDto.Id);

            if (chain == null)
            {
                throw new EntityNotFoundException(chainDto.Id);
            }

            this.mapper.Map(chainDto, chain);

            this.context.SaveChanges();
        }
    }
}
