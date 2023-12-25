using FluentValidation;
using Shopfloor.IED.Application.Query.WeavingRusticFabricSpecs;

namespace Shopfloor.IED.Application.Validations.WeavingRusticFabricSpecs
{
    public class GetWeavingRusticFabricSpecsQueryValidator : AbstractValidator<GetWeavingRusticFabricSpecsQuery>
    {
        public GetWeavingRusticFabricSpecsQueryValidator()
        {
            RuleFor(p => p.BackgroundType)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.BorderType)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.MachineType)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
