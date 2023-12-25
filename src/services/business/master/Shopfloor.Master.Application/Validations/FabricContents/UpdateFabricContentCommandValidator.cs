using FluentValidation;
using Shopfloor.Master.Application.Command.Divisions;
using Shopfloor.Master.Application.Command.FabricContents;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.FabricContents
{
    public class UpdateFabricContentCommandValidator : AbstractValidator<UpdateFabricContentCommand>
    {
        private readonly IFabricContentRepository _fabricContentRepository;
        public UpdateFabricContentCommandValidator(IFabricContentRepository fabricContentRepository)
        {
            _fabricContentRepository = fabricContentRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateFabricContentCommand command, CancellationToken cancellationToken)
        {
            return await _fabricContentRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
