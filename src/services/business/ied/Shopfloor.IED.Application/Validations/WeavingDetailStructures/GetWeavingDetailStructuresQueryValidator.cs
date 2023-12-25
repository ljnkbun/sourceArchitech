﻿using FluentValidation;
using Shopfloor.IED.Application.Query.WeavingDetailStructures;

namespace Shopfloor.IED.Application.Validations.WeavingDetailStructures
{
    public class GetWeavingDetailStructuresQueryValidator : AbstractValidator<GetWeavingDetailStructuresQuery>
    {
        public GetWeavingDetailStructuresQueryValidator()
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
