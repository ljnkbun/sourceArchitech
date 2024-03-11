using FluentValidation;
using Shopfloor.IED.Application.Command.LiquorRatios;
using Shopfloor.IED.Domain.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shopfloor.IED.Application.Validations.LiquorRatios
{
    public class UpdateLiquorRatioCommandValidator : AbstractValidator<UpdateLiquorRatioCommand>
    {
        private readonly ILiquorRatioRepository _repository;
        public UpdateLiquorRatioCommandValidator(ILiquorRatioRepository repository)
        {
            _repository = repository;
            RuleFor(p => p.Value)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p).MustAsync(IsValueUniqueAsync).WithMessage("Value must unique.");
        }
        private async Task<bool> IsValueUniqueAsync(UpdateLiquorRatioCommand command, CancellationToken token)
        {
            return await _repository.IsValueUniqueAsync(command.Value, command.Id);
        }
    }
}
