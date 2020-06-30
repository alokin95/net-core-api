using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Implementation.Validations
{
    public class CreateChainValidation : AbstractValidator<CreateChainDto>
    {
        private readonly Database context;
        public CreateChainValidation(Database context)
        {
            this.context = context;

            RuleFor(c => c.Name)
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(30)
                .Must(NameIsUnique)
                .WithMessage(chainDto => chainDto.Name + " already exists. Please pick another.");

            RuleFor(c => c.ManagerId)
                .NotEmpty()
                .Must(ManagerExist)
                .WithMessage("The selected manager does not exist");
        }

        private bool ManagerExist(int id)
        {
            return this.context.Users.Any(u => u.Id == id);
        }

        private bool NameIsUnique(string chainName)
        {
            return !this.context.Chains.Any(c => c.Name == chainName);
        }
    }
}
