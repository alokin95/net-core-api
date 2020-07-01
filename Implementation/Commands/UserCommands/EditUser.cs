using Application.Commands.UserCommands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Implementation.Commands.UserCommands
{
    public class EditUser : IEditUserCommand
    {
        public int Id => 26;

        public string Name => "Edit user";

        private readonly Database context;
        private readonly IMapper mapper;
        private readonly EditUserValidation editUserValidation;

        public EditUser(Database context, IMapper mapper, EditUserValidation editUserValidation)
        {
            this.context = context;
            this.mapper = mapper;
            this.editUserValidation = editUserValidation;
        }

        public void Execute(UserDto dto)
        {
            this.editUserValidation.ValidateAndThrow(dto);

            var user = this.context.Users.Find(dto.Id);

            if (user == null)
            {
                throw new EntityNotFoundException(dto.Id);
            }

            this.mapper.Map(dto, user);

            this.context.SaveChanges();
        }
    }
}
