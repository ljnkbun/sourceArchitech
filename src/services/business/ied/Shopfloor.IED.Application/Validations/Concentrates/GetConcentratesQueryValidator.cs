﻿using FluentValidation;
using Shopfloor.IED.Application.Query.Concentrates;

namespace Shopfloor.IED.Application.Validations.Concentrates
{
    public class GetConcentratesQueryValidator : AbstractValidator<GetConcentratesQuery>
    {
        public GetConcentratesQueryValidator()
        {
            RuleFor(p => p.Code)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
