using FluentValidation;
using Shopfloor.IED.Application.Command.SewingFeatures;
using Shopfloor.IED.Application.Command.SewingMacros;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingFeatures
{
    public class UpdateSewingFeatureCommandValidator : AbstractValidator<UpdateSewingFeatureCommand>
    {
        private readonly ISewingFeatureRepository _SewingFeatureRepository;
        public UpdateSewingFeatureCommandValidator(ISewingFeatureRepository SewingFeatureRepository)
        {
            _SewingFeatureRepository = SewingFeatureRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");

            RuleForEach(e => e.SewingFeatureBOLs).Must(r => r.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateSewingFeatureCommand command, CancellationToken token)
        {
            return await _SewingFeatureRepository.IsUniqueAsync(command.Code, command.Id);
        }
        private bool IsLineNumberUnique(UpdateSewingFeatureCommand command)
        {
            return command?.SewingFeatureBOLs.DistinctBy(m => m.LineNumber).Count() == command?.SewingFeatureBOLs.Count();
        }
    }
}
