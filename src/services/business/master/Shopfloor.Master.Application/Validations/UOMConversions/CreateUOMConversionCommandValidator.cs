using FluentValidation;
using Shopfloor.Master.Application.Command.UOMConversions;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.UOMConversions
{
    public class CreateUOMConversionCommandValidator : AbstractValidator<CreateUOMConversionCommand>
    {
        private readonly IUOMRepository _uomRepository;
        private readonly IUOMConversionRepository _uomConversionRepository;

        public CreateUOMConversionCommandValidator(IUOMRepository uomRepository, IUOMConversionRepository uomConversionRepository)
        {
            _uomRepository = uomRepository;
            RuleFor(p => p.Value)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0");

            RuleFor(p => p.FromUOMId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(IsExistUOM);

            RuleFor(p => p.ToUOMId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(IsExistUOM);

            RuleFor(p => p.Action)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            _uomConversionRepository = uomConversionRepository;
        }
        private async Task<bool> IsExistUOM(int id, CancellationToken cancellationToken)
        {
            return await _uomRepository.GetByIdAsync(id) != null;
        }

    }
}
