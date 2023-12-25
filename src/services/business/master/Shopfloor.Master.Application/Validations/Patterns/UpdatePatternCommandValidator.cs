using FluentValidation;
using Shopfloor.Master.Application.Command.Origins;
using Shopfloor.Master.Application.Command.Patterns;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Patterns
{
    public class UpdatePatternCommandValidator : AbstractValidator<UpdatePatternCommand>
    {
        private readonly IPatternRepository _patternRepository;
        public UpdatePatternCommandValidator(IPatternRepository patternRepository)
        {
            _patternRepository = patternRepository; 
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdatePatternCommand command, CancellationToken cancellationToken)
        {
            return await _patternRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
