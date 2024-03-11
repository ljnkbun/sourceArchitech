using FluentValidation;
using Shopfloor.Planning.Application.Query.PORDetails;

namespace Shopfloor.Planning.Application.Validations.WfxPORProperties
{
    public class GetPORDetailQueryValidator : AbstractValidator<GetPORDetailsQuery>
    {
        public GetPORDetailQueryValidator()
        {
            RuleFor(p => p.Color)
                 .MaximumLength(250)
                 .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Size)
                .MaximumLength(200)
                .WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Type)
                .IsInEnum()
                .WithMessage("Value is not part of the enum.");
        }
    }
}
