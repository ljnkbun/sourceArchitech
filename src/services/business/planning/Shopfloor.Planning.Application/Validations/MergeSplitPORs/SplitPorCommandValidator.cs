using FluentValidation;
using Shopfloor.Planning.Application.Command.MergeSplitPORs;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.MergeSplitPORs
{
    public class SplitPorCommandValidator : AbstractValidator<SplitPORCommand>
    {
        private readonly IPORRepository _pORRepository;
        public SplitPorCommandValidator(IPORRepository pORRepository)
        {
            _pORRepository = pORRepository;

            RuleFor(p => p)
                .MustAsync(ValidatorQuantityPor)
                .WithMessage("{PropertyName} must unqui.");
        }

        private async Task<bool> ValidatorQuantityPor(SplitPORCommand command, CancellationToken cancellationToken)
        {
            var entity = await _pORRepository.GetByIdAsync(command.PORId);
            return (command.SplitPorDetailModels.Sum(x => x.RemainingQuantity) <= entity.RemainingQuantity);
        }
    }
}
