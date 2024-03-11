using FluentValidation;
using Shopfloor.IED.Application.Command.LiquorRatios;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.LiquorRatios
{
    public class CreateLiquorRatioCommandValidator : AbstractValidator<CreateLiquorRatioCommand>
    {
        private readonly ILiquorRatioRepository _repository;
        public CreateLiquorRatioCommandValidator(ILiquorRatioRepository repository)
        {
            _repository = repository;
            RuleFor(p => p.Value)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(IsValueUniqueAsync).WithMessage("{PropertyName} must unique.");
        }
        private async Task<bool> IsValueUniqueAsync(decimal value, CancellationToken token)
        {
            return await _repository.IsValueUniqueAsync(value);
        }
    }
}
