using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRequests;

namespace Shopfloor.IED.Application.Validations.DyeingTBRequests
{
    public class ChangeStatusDyeingTBRequestCommandValidator : AbstractValidator<ChangeStatusDyeingTBRequestCommand>
    {
        public ChangeStatusDyeingTBRequestCommandValidator()
        {
            RuleFor(p => p.Status)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}