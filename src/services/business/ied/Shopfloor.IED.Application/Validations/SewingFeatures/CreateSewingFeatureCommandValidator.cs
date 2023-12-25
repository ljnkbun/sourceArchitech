using FluentValidation;
using Shopfloor.IED.Application.Command.SewingFeatures;
using Shopfloor.IED.Application.Command.SewingMacros;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingFeatures
{
    public class CreateSewingFeatureCommandValidator : AbstractValidator<CreateSewingFeatureCommand>
    {
        private readonly ISewingFeatureRepository _SewingFeatureRepository;
        public CreateSewingFeatureCommandValidator(ISewingFeatureRepository SewingFeatureRepository)
        {
            _SewingFeatureRepository = SewingFeatureRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
         
            RuleForEach(e => e.SewingFeatureBOLs).Must(r => r.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _SewingFeatureRepository.IsUniqueAsync(code);
        }
        private bool IsLineNumberUnique(CreateSewingFeatureCommand command)
        {
            return command?.SewingFeatureBOLs.DistinctBy(m => m.LineNumber).Count() == command?.SewingFeatureBOLs.Count();
        }
    }
}
