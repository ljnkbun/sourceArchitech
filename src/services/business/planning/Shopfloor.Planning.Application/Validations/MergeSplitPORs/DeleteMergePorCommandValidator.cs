using FluentValidation;
using Shopfloor.Planning.Application.Command.MergeSplitPORs;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.MergeSplitPORs
{
    public class DeleteMergePorCommandValidator : AbstractValidator<DeleteMergeSplitPORCommand>
    {
        private readonly IPORRepository _pORRepository;
        public DeleteMergePorCommandValidator(IPORRepository pORRepository)
        {
            _pORRepository = pORRepository;

            RuleFor(p => p)
                .MustAsync(ValidatorPorInWfx)
                .WithMessage("{PropertyName} Not Delete POR in WFX.");
        }

        private async Task<bool> ValidatorPorInWfx(DeleteMergeSplitPORCommand command, CancellationToken cancellationToken)
        {
            var entity = await _pORRepository.GetByIdAsync(command.PorId);
            return (entity.TypePOR != Domain.Enums.PorType.ToWfx);
        }
    }
}
