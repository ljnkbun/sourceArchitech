using FluentValidation;
using Shopfloor.Master.Application.Command.Factories;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Factories
{
    public class UpdateFactoryCommandValidator : AbstractValidator<UpdateFactoryCommand>
    {
        private readonly IDivisionRepository _divisionRepository;
        private readonly IFactoryRepository _factoryRepository;
        public UpdateFactoryCommandValidator(IFactoryRepository factoryRepository,
            IDivisionRepository divisionRepository)
        {
            _factoryRepository = factoryRepository;
            _divisionRepository = divisionRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.DivisionId)
             .MustAsync(IsExistDivision).WithMessage("{PropertyName} not exist in Division table.");
            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }
        private async Task<bool> IsExistDivision(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
                return true;
            return await _divisionRepository.GetByIdAsync(id.Value) != null;
        }
        private async Task<bool> IsUniqueAsync(UpdateFactoryCommand command, CancellationToken cancellationToken)
        {
            return await _factoryRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
