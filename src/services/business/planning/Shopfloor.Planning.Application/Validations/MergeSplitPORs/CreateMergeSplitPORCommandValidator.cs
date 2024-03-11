using FluentValidation;
using Shopfloor.Planning.Application.Command.MergeSplitPORs;

namespace Shopfloor.Planning.Application.Validations.MergeSplitPORs
{
    public class CreateMergeSplitPORCommandValidator : AbstractValidator<CreateMergeSplitPORCommand>
    {
        public CreateMergeSplitPORCommandValidator()
        {
            RuleFor(r => r.FromPORId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("{PropertyName}  is required.");

            RuleFor(r => r.ToPORId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("{PropertyName}  is required.");

            RuleFor(r => r.Quantity)
                .GreaterThan(0)
                .WithMessage("{PropertyName}  is required.");
        }
    }
}
