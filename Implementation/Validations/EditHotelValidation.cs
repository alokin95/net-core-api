﻿using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Implementation.Validations
{
    public class EditHotelValidation : AbstractValidator<CreateHotelDto>
    {
        private readonly Database context;
        public EditHotelValidation(Database context)
        {
            this.context = context;

            RuleFor(dto => dto.Name)
                .NotEmpty()
                .WithMessage("The name field is required")
                .Must(HotelNameMustBeUnique)
                .WithMessage("Hotel name already taken");

            RuleFor(dto => dto.ManagerId)
                .NotNull()
                .Must(ManagerMustExist)
                .WithMessage("The selected hotel manager does not exist. Please pick another one");

            RuleFor(dto => dto.ChainID)
                .NotNull()
                .Must(ChainMustExist)
                .WithMessage("The selected hotel chain does not exist");

            RuleFor(dto => dto.Location)
                .NotNull()
                .When(dto => dto.Location != null)
                .NotEmpty()
                .SetValidator(new EditLocationValidation(this.context));
        }

        private bool HotelNameMustBeUnique(CreateHotelDto dto, string name)
        {
            return !this.context.Hotels.Any(h => h.Name.ToLower() == name.ToLower() && dto.Id != h.Id);
        }

        private bool ChainMustExist( int chainId)
        {
            return this.context.Chains.Any(c => c.Id == chainId);
        }

        private bool ManagerMustExist(int managerId)
        {
            return this.context.Users.Any(u => u.Id == managerId);
        }
    }
}