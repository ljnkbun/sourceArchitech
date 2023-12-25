using FluentValidation;
using Shopfloor.Master.Application.Parameters.SizeOrWidthRanges;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.SizeOrWidthRanges
{
    public class CreateSizeOrWidthRangeCommandValidator : AbstractValidator<SizeOrWidthRangeParameter>
    {
        private readonly ISizeOrWidthRangeRepository _sizeOrWidthRangeRepository;
        public CreateSizeOrWidthRangeCommandValidator(ISizeOrWidthRangeRepository sizeOrWidthRangeRepository)
        {
            _sizeOrWidthRangeRepository = sizeOrWidthRangeRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _sizeOrWidthRangeRepository.IsUniqueAsync(code);
        }
    }
}
