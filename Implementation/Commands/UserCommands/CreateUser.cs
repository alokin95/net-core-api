using Application.Commands.UserCommands;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domain.Entity;
using FluentValidation;
using Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.UserCommands
{
    public class CreateUser : ICreateUserCommand
    {
        public int Id => 23;

        public string Name => "Create user";

        private readonly Database context;
        private readonly IMapper mapper;
        private readonly CreateUserValidation createUserValidaton;

        public CreateUser(Database context, IMapper mapper, CreateUserValidation createUserValidaton)
        {
            this.context = context;
            this.mapper = mapper;
            this.createUserValidaton = createUserValidaton;
        }

        public void Execute(UserDto dto)
        {
            this.createUserValidaton.ValidateAndThrow(dto);

            var user = this.mapper.Map<User>(dto);

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }
    }
}
