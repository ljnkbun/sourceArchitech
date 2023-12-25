using FluentValidation;
using Shopfloor.Master.Application.Command.FiberTypes;
using Shopfloor.Master.Application.Command.Genders;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Genders
{
    public class UpdateGenderCommandValidator : AbstractValidator<UpdateGenderCommand>
    {
        private readonly IGenderRepository _genderRepository;
        public UpdateGenderCommandValidator(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateGenderCommand command, CancellationToken cancellationToken)
        {
            return await _genderRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
