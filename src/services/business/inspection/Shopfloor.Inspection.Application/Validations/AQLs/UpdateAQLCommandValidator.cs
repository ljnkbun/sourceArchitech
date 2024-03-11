using FluentValidation;
using Shopfloor.Inspection.Application.Command.AQLs;

namespace Shopfloor.Inspection.Application.Validations.AQLs
{
    public class UpdateAQLCommandValidator : AbstractValidator<UpdateAQLCommand>
    {
        public UpdateAQLCommandValidator()
        {
            RuleFor(r => r.AQLVersionId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.LotSizeFrom).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.LotSizeTo).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.SampleSize).GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }

    }
}
