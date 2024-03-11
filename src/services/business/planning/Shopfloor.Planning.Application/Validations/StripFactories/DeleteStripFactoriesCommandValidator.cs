using FluentValidation;
using Shopfloor.Planning.Application.Command.StripFactories;

namespace Shopfloor.Planning.Application.Validations.StripFactories
{
    public class DeleteStripFactoriesCommandValidator : AbstractValidator<DeleteStripFactoriesCommand>
    {
        public DeleteStripFactoriesCommandValidator()
        {
            RuleFor(r => r.Ids)
                .Must(x => x.Count > 0).WithMessage("{PropertyName} is required.");
        }
    }
}
