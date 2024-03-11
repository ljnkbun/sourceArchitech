using FluentValidation;
using Shopfloor.Planning.Application.Command.StripFactorySchedules;

namespace Shopfloor.Planning.Application.Validations.StripFactorySchedules
{
    public class UpdateStripFactoryScheduleCommandValidator : AbstractValidator<UpdateStripFactoryScheduleCommand>
    {
        public UpdateStripFactoryScheduleCommandValidator()
        {
            RuleFor(r => r.StripFactoryId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.StripScheduleId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
        }
    }
}
