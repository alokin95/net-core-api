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
    public class EditChainValidation : AbstractValidator<CreateChainDto>
    {
        private readonly Database context;
        public EditChainValidation(Database context)
        {
            this.context = context;

            RuleFor(dto => dto.Name)
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(100)
                .Must(NameMustBeUnique)
                .WithMessage("The selected name is already taken");

            RuleFor(dto => dto.ManagerId)
                .NotNull()
                .Must(ManagerMustExist)
                .WithMessage("The selected manager does not exist");
        }

        private bool ManagerMustExist(CreateChainDto dto, int managerId)
        {
            return this.context.Users.Any(user => user.Id == dto.ManagerId);
        }

        private bool NameMustBeUnique(CreateChainDto dto, string name)
        {
            return !this.context.Chains.Any(chain => chain.Name == dto.Name && chain.Id != dto.Id);
        }
    }
}
