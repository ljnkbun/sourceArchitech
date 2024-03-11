using FluentValidation;
using Shopfloor.IED.Application.Command.Requests;

namespace Shopfloor.IED.Application.Validations.Requests
{
    public class CreateRequestCommandValidator : AbstractValidator<CreateRequestCommand>
    {
        public CreateRequestCommandValidator()
        {
            RuleFor(p => p.RequestTypeId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.RequestDivisions)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleForEach(x => x.RequestDivisions).ChildRules(child =>
            {
                child.RuleFor(p => p.RequestDivisionProcesses)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();
            });
        }
    }
}
