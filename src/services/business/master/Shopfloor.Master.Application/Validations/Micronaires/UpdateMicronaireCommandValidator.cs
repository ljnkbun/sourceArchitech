using FluentValidation;
using Shopfloor.Master.Application.Command.Genders;
using Shopfloor.Master.Application.Command.Micronaires;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Micronaires
{
    public class UpdateMicronaireCommandValidator : AbstractValidator<UpdateMicronaireCommand>
    {
        private readonly IMicronaireRepository _micronaireRepository;
        public UpdateMicronaireCommandValidator(IMicronaireRepository micronaireRepository)
        {
            _micronaireRepository = micronaireRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateMicronaireCommand command, CancellationToken cancellationToken)
        {
            return await _micronaireRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
