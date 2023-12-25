using FluentValidation;
using Shopfloor.Master.Application.Command.Counts;
using Shopfloor.Master.Application.Command.CountTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.CountTypes
{
    public class UpdateCountTypeCommandValidator : AbstractValidator<UpdateCountTypeCommand>
    {
        private readonly ICountTypeRepository _countTypeRepository;
        public UpdateCountTypeCommandValidator(ICountTypeRepository countTypeRepository)
        {
            _countTypeRepository = countTypeRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateCountTypeCommand command, CancellationToken cancellationToken)
        {
            return await _countTypeRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
