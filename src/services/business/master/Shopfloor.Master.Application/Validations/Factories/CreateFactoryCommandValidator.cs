using FluentValidation;
using Shopfloor.Master.Application.Command.Factories;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Factories
{
    public class CreateFactoryCommandValidator : AbstractValidator<CreateFactoryCommand>
    {
        private readonly IDivisionRepository _divisionRepository;
        private readonly IFactoryRepository _factoryRepository;
        public CreateFactoryCommandValidator(IDivisionRepository divisionRepository, IFactoryRepository factoryRepository)
        {
            _factoryRepository = factoryRepository;
            _divisionRepository = divisionRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.DivisionId)
                .MustAsync(IsExistDivision).WithMessage("{PropertyName} not exist in Division table.");
        }
        private async Task<bool> IsExistDivision(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
                return true;
            return await _divisionRepository.GetByIdAsync(id.Value) != null;
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _factoryRepository.IsUniqueAsync(code);
        }
    }
}
