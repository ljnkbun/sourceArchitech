using FluentValidation;
using Shopfloor.Inspection.Application.Command.QCDefinitionDefects;

namespace Shopfloor.Inspection.Application.Validations.QCDefinitionDefects
{
    public class CreateQCDefinitionDefectCommandValidator : AbstractValidator<CreateQCDefinitionDefectCommand>
    {
        public CreateQCDefinitionDefectCommandValidator()
        {
            RuleFor(r => r.QCDefinitionId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.QCDefectId).GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }
    }
}
