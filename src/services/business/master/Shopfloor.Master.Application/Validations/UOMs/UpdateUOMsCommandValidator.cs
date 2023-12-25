using FluentValidation;
using Shopfloor.Master.Application.Command.Twists;
using Shopfloor.Master.Application.Command.UOMs;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.UOMs
{
    public class UpdateUOMsCommandValidator : AbstractValidator<UpdateUOMCommand>
    {
        private readonly IUOMRepository _oUMrepository;
        public UpdateUOMsCommandValidator(IUOMRepository uOMRepository)
        {
            _oUMrepository = uOMRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateUOMCommand command, CancellationToken cancellationToken)
        {
            return await _oUMrepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
