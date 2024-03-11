using FluentValidation;
using Shopfloor.Planning.Application.Command.StripFactoryScheduleDetails;

namespace Shopfloor.Planning.Application.Validations.StripFactoryScheduleDetails
{
    public class UpdateStripFactoryScheduleDetailCommandValidator : AbstractValidator<UpdateStripFactoryScheduleDetailCommand>
    {
        public UpdateStripFactoryScheduleDetailCommandValidator()
        {
        }
    }
}
