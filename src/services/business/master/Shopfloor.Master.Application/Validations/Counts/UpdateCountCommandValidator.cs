using FluentValidation;
using Shopfloor.Master.Application.Command.Counts;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Counts
{
    public class UpdateCountCommandValidator : AbstractValidator<UpdateCountCommand>
    {
        private readonly ICountRepository _countRepository;
        public UpdateCountCommandValidator(ICountRepository countRepository)
        {
            _countRepository = countRepository;

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

        private async Task<bool> IsUniqueAsync(UpdateCountCommand command, CancellationToken cancellationToken)
        {
            return await _countRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
