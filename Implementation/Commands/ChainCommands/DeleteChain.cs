using Application.Commands.ChainCommands;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.ChainCommands
{
    public class DeleteChain : IDeleteChainCommand
    {
        public int Id => 8;

        public string Name => "Delete chain";

        private readonly Database context;

        public DeleteChain(Database context)
        {
            this.context = context;
        }

        public void Execute(int id)
        {
            var chain = this.context.Chains.Find(id);

            if (chain == null)
            {
                throw new EntityNotFoundException(id);
            }

            chain.DeletedAt = DateTime.Now;

            this.context.SaveChanges();
        }
    }
}
