using FluentValidation;
using Shopfloor.Planning.Application.Command.StripFactoryScheduleDetails;

namespace Shopfloor.Planning.Application.Validations.StripFactoryScheduleDetails
{
    public class CreateStripFactoryScheduleDetailCommandValidator : AbstractValidator<CreateStripFactoryScheduleDetailCommand>
    {
        public CreateStripFactoryScheduleDetailCommandValidator()
        {
        }
    }
}
