using FluentValidation;
using Shopfloor.Planning.Application.Command.StripFactories;

namespace Shopfloor.Planning.Application.Validations.StripFactories
{
    public class SaveStripFactoriesCommandValidator : AbstractValidator<SaveStripFactoriesCommand>
    {
        public SaveStripFactoriesCommandValidator()
        {
            RuleForEach(r => r.StripFactories).SetValidator(new UpdateStripFactoryCommandValidator());
        }
    }
}
