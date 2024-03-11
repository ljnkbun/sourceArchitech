using FluentValidation;
using Shopfloor.Planning.Application.Command.StripSchedules;

namespace Shopfloor.Planning.Application.Validations.StripSchedules
{
    public class CalculateStripScheduleCommandValidator : AbstractValidator<CalculateStripScheduleCommand>
    {
        public CalculateStripScheduleCommandValidator()
        {
            RuleFor(p => p)
                .Must(p => p.MachineId > 0 || p.LineId > 0)
                .WithMessage("LineId or MachineId must be not null");

            RuleFor(p => p.CalendarId)
                .GreaterThan(0);

            RuleFor(p => p.FromWorkingHours)
                .GreaterThan(-1).LessThanOrEqualTo(24);
        }
    }
}
