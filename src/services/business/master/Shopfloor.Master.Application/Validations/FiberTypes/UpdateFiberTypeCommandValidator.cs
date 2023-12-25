using FluentValidation;
using Shopfloor.Master.Application.Command.FabricWidths;
using Shopfloor.Master.Application.Command.FiberTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.FiberTypes
{
    public class UpdateFiberTypeCommandValidator : AbstractValidator<UpdateFiberTypeCommand>
    {
        private readonly IFiberTypeRepository _fiberTypeRepository;
        public UpdateFiberTypeCommandValidator(IFiberTypeRepository fiberTypeRepository)
        {
            _fiberTypeRepository = fiberTypeRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters."); ;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateFiberTypeCommand command, CancellationToken cancellationToken)
        {
            return await _fiberTypeRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
