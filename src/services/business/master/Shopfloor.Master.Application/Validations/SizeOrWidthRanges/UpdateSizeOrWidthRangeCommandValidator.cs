using FluentValidation;
using Shopfloor.Master.Application.Command.ShipmentTerms;
using Shopfloor.Master.Application.Command.SizeOrWidthRanges;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.ColorCards
{
    public class UpdateSizeOrWidthRangeCommandValidator : AbstractValidator<UpdateSizeOrWidthRangeCommand>
    {
        private readonly ISizeOrWidthRangeRepository _sizeOrWidthRangeRepository;
        public UpdateSizeOrWidthRangeCommandValidator(ISizeOrWidthRangeRepository sizeOrWidthRangeRepository)
        {

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            _sizeOrWidthRangeRepository = sizeOrWidthRangeRepository;

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateSizeOrWidthRangeCommand command, CancellationToken cancellationToken)
        {
            return await _sizeOrWidthRangeRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
