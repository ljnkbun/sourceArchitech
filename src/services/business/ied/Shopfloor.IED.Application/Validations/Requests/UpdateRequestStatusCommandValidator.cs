using FluentValidation;
using Shopfloor.IED.Application.Command.Requests;

namespace Shopfloor.IED.Application.Validations.Requests
{
    public class UpdateRequestStatusCommandValidator : AbstractValidator<UpdateRequestStatusCommand>
    {
        public UpdateRequestStatusCommandValidator()
        {
            RuleFor(p => p.Status).IsInEnum();
        }
    }
}
