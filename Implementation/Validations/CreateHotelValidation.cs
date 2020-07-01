using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Implementation.Validations
{
    public class CreateHotelValidation : AbstractValidator<CreateHotelDto>
    {
        private readonly Database context;
        public CreateHotelValidation(Database context)
        {
            this.context = context;

            RuleFor(dto => dto.Name)
                .NotEmpty()
                .WithMessage("The name field is required")
                .Must(HotelNameMustBeUnique)
                .WithMessage("Hotel name already taken");

            RuleFor(dto => dto.ManagerId)
                .NotEmpty()
                .Must(ManagerMustExist)
                .WithMessage("The selected hotel manager does not exist. Please pick another one");

            RuleFor(dto => dto.ChainID)
                .NotEmpty()
                .Must(ChainMustExist)
                .WithMessage("The selected hotel chain does not exist");

            RuleFor(dto => dto.Location)
                .NotEmpty()
                .When(dto => dto.Location != null)
                .NotEmpty()
                .SetValidator(new CreateLocationValidation(this.context));
        }

        private bool HotelNameMustBeUnique(string name)
        {
            return !this.context.Hotels.Any(h => h.Name.ToLower() == name.ToLower());
        }

        private bool ChainMustExist(int chainId)
        {
            return this.context.Chains.Any(c => c.Id == chainId);
        }

        private bool ManagerMustExist(int managerId)
        {
            return this.context.Users.Any(u => u.Id == managerId);
        }
    }
}
