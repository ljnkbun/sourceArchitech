using FluentValidation;
using Shopfloor.Master.Application.Command.YarnCompositions;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.YarnCompositions
{
    public class UpdateYarnCompositionCommandValidator : AbstractValidator<UpdateYarnCompositionCommand>
    {
        private readonly IYarnCompositionRepository _yarnCompositionRepository;
        public UpdateYarnCompositionCommandValidator(IYarnCompositionRepository yarnCompositionRepository)
        {
            _yarnCompositionRepository = yarnCompositionRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateYarnCompositionCommand command, CancellationToken cancellationToken)
        {
            return await _yarnCompositionRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
