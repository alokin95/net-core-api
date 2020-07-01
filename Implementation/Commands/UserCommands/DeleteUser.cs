using Application.Commands.UserCommands;
using Application.Exceptions;
using DataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.UserCommands
{
    public class DeleteUser : IDeleteUserCommand
    {
        public int Id => 27;

        public string Name => "Delete user";

        private readonly Database context;

        public DeleteUser(Database context)
        {
            this.context = context;
        }

        public void Execute(int id)
        {
            var user = this.context.Users.Find(id);

            if (user == null)
            {
                throw new EntityNotFoundException(id);
            }

            user.Delete();
            this.context.SaveChanges();
        }
    }
}
