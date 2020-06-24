using API.DTO;
using API.Errors;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class ApiExtensions
    {
        public static IActionResult ValidationErrors(this ValidationResult result)
        {
            var errors = result.Errors.Select(x => new ValidationError
            {
                Message = x.ErrorMessage,
                Property = x.PropertyName
            });

            return new UnprocessableEntityObjectResult(new
            {
                Errors = errors
            });
        }

        public static IRuleBuilderOptions<T, TProperty> LocationMustBeUnique<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule, string format)
        {
            return rule.WithMessage("The address already exists in the database");
        }
    }
}
