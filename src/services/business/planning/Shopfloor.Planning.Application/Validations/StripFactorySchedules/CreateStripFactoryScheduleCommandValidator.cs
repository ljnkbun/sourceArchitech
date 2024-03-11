using FluentValidation;
using Shopfloor.Planning.Application.Command.StripFactorySchedules;

namespace Shopfloor.Planning.Application.Validations.StripFactorySchedules
{
    public class CreateStripFactoryScheduleCommandValidator : AbstractValidator<CreateStripFactoryScheduleCommand>
    {
        public CreateStripFactoryScheduleCommandValidator()
        {
            RuleFor(r => r.StripFactoryId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.StripScheduleId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
        }
    }
}
