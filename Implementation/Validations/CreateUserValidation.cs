using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Implementation.Validations
{
    public class CreateUserValidation : AbstractValidator<UserDto>
    {
        private readonly Database context;
        public CreateUserValidation(Database context)
        {
            this.context = context;

            RuleFor(u => u.Email)
                .NotEmpty()
                .Must(EmailMustBeUnique)
                .WithMessage("Email already taken");

            RuleFor(u => u.Firstname)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(u => u.Lastname)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

        }

        private bool EmailMustBeUnique(string email)
        {
            return !this.context.Users.Any(u => u.Email.ToLower() == email.ToLower());
        }
    }
}
