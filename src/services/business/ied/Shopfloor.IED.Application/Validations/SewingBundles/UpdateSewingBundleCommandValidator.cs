using FluentValidation;
using Shopfloor.IED.Application.Command.SewingBundles;
using Shopfloor.IED.Application.Command.SewingComponentGroups;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingBundles
{
    public class UpdateSewingBundleCommandValidator : AbstractValidator<UpdateSewingBundleCommand>
    {
        private readonly ISewingBundleRepository _sewingBundle;

        public UpdateSewingBundleCommandValidator(ISewingBundleRepository sewingBundle)
        {
            _sewingBundle = sewingBundle;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must greater than or equal to 0.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateSewingBundleCommand command, CancellationToken token)
        {
            return await _sewingBundle.IsUniqueAsync(command.Code, command.Id);
        }
    }
}