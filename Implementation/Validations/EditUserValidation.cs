using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validations
{
    public class EditUserValidation : AbstractValidator<UserDto>
    {
        private readonly Database context;
        public EditUserValidation(Database context)
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

        private bool EmailMustBeUnique(UserDto dto, string email)
        {
            return !this.context.Users.Any(u => u.Email.ToLower() == email.ToLower() && dto.Id != u.Id);
        }
    }
}
