using FluentValidation;
using Shopfloor.Planning.Application.Command.StripFactoryDetails;

namespace Shopfloor.Planning.Application.Validations.StripFactoryDetails
{
    public class CreateStripFactoryDetailCommandValidator : AbstractValidator<CreateStripFactoryDetailCommand>
    {
        public CreateStripFactoryDetailCommandValidator()
        {
            RuleFor(r => r.PorDetailId)
                    .GreaterThan(0).WithMessage("{PropertyName}  is required.");

            RuleFor(r => r.Color)
                .NotNull().WithMessage("{PropertyName}  is not null.")
                .MaximumLength(200).WithMessage("{PropertyName}  is max length.");

            RuleFor(r => r.Size)
                .NotNull().WithMessage("{PropertyName}  is not null.")
                .MaximumLength(200).WithMessage("{PropertyName}  is max length.");

            RuleFor(r => r.UOM)
                .NotNull().WithMessage("{PropertyName}  is not null.")
                .MaximumLength(200).WithMessage("{PropertyName}  is max length.");

            RuleFor(r => r.Quantity)
                .GreaterThan(0).WithMessage("{PropertyName}  is required.");

            RuleFor(r => r.RemainingQuantity)
                .GreaterThan(0).WithMessage("{PropertyName}  is required.");

            RuleFor(r => r.TypePORDetail)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(r => r.StripFactoryId)
                .GreaterThan(0).WithMessage("{PropertyName}  is required.");
        }
    }
}
