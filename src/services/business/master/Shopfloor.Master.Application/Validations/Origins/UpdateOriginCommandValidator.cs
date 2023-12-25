using FluentValidation;
using Shopfloor.Master.Application.Command.Genders;
using Shopfloor.Master.Application.Command.Origins;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Origins
{
    public class UpdateOriginCommandValidator : AbstractValidator<UpdateOriginCommand>
    {
        private readonly IOriginRepository _originRepository;
        public UpdateOriginCommandValidator(IOriginRepository originRepository)
        {
            _originRepository = originRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateOriginCommand command, CancellationToken cancellationToken)
        {
            return await _originRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
