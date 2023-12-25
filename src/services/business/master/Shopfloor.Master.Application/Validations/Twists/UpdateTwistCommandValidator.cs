using FluentValidation;
using Shopfloor.Master.Application.Command.Themes;
using Shopfloor.Master.Application.Command.Twists;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Twists
{
    public class UpdateTwistCommandValidator : AbstractValidator<UpdateTwistCommand>
    {
        private readonly ITwistRepository _twistRepository;
        public UpdateTwistCommandValidator(ITwistRepository twistRepository)
        {
            _twistRepository = twistRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateTwistCommand command, CancellationToken cancellationToken)
        {
            return await _twistRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
