using FluentValidation;
using Shopfloor.Master.Application.Command.Twists;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Twists
{
    public class CreateTwistCommandValidator : AbstractValidator<CreateTwistCommand>
    {
        private readonly ITwistRepository _twistRepository;
        public CreateTwistCommandValidator(ITwistRepository twistRepository)
        {
            _twistRepository = twistRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _twistRepository.IsUniqueAsync(code);
        }
    }
}
