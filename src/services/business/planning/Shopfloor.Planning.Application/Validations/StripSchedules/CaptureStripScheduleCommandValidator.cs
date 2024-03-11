using FluentValidation;
using Shopfloor.Planning.Application.Command.StripSchedules;

namespace Shopfloor.Planning.Application.Validations.StripSchedules
{
    public class CaptureStripScheduleCommandValidator : AbstractValidator<CaptureStripScheduleCommand>
    {
        public CaptureStripScheduleCommandValidator()
        {
            RuleFor(r => r.ProcessId).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.FromDate).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ToDate).NotEmpty().WithMessage("{PropertyName}  is required.");
        }
    }
}
