﻿using FluentValidation;
using Shopfloor.IED.Application.Query.DyeingTBRVersions;

namespace Shopfloor.IED.Application.Validations.DyeingTBRVersions
{
    public class GetDyeingTBRVersionsQueryValidator : AbstractValidator<GetDyeingTBRVersionsQuery>
    {
        public GetDyeingTBRVersionsQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
        }
    }
}