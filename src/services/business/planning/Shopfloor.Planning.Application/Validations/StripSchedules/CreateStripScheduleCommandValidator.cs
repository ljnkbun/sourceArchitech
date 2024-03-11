using FluentValidation;
using Shopfloor.Planning.Application.Command.StripSchedules;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.StripSchedules
{
    public class CreateStripScheduleCommandValidator : AbstractValidator<CreateStripScheduleCommand>
    {
        public CreateStripScheduleCommandValidator()
        {
            RuleFor(p => p.FromDate)
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ToDate)
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
