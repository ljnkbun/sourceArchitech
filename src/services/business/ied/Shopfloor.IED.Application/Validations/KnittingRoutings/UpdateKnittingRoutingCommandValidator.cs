using FluentValidation;
using Shopfloor.IED.Application.Command.KnittingRoutings;

namespace Shopfloor.IED.Application.Validations.KnittingRoutings
{
    public class UpdateKnittingRoutingCommandValidator : AbstractValidator<UpdateKnittingRoutingCommand>
    {
        public UpdateKnittingRoutingCommandValidator()
        {
            RuleFor(p => p.KnittingProcess)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.KnittingOperationCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.KnittingProcessCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.KnittingOperation)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.MachineTypeName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p).Must(p => p.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
        }
    }
}
