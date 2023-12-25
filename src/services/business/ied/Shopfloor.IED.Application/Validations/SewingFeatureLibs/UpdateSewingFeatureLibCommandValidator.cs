using FluentValidation;
using Shopfloor.IED.Application.Command.SewingFeatureLibs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingFeatureLibs
{
    public class UpdateSewingFeatureLibCommandValidator : AbstractValidator<UpdateSewingFeatureLibCommand>
    {
        private readonly ISewingFeatureLibRepository _sewingFeatureLibRepository;
        public UpdateSewingFeatureLibCommandValidator(ISewingFeatureLibRepository sewingFeatureLibRepository)
        {
            _sewingFeatureLibRepository = sewingFeatureLibRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateSewingFeatureLibCommand command, CancellationToken token)
        {
            return await _sewingFeatureLibRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
