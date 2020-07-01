using Application.Commands.UserCommands;
using Application.DataTransfer;
using Application.Email;
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
        private readonly IEmailSender emailSender;

        public CreateUser(Database context, IMapper mapper, CreateUserValidation createUserValidaton, IEmailSender emailSender)
        {
            this.context = context;
            this.mapper = mapper;
            this.createUserValidaton = createUserValidaton;
            this.emailSender = emailSender;
        }

        public void Execute(UserDto dto)
        {
            this.createUserValidaton.ValidateAndThrow(dto);

            var user = this.mapper.Map<User>(dto);

            this.context.Users.Add(user);
            this.context.SaveChanges();

            this.emailSender.Send(new EmailDto
            {
                Content = "<h1>Welcome</h1>",
                To = dto.Email,
                Subject = "Welcome"
            });
        }
    }
}
