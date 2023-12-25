using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Shopfloor.Master.Application.Command.Structures;
using Shopfloor.Master.Domain.Interfaces;
using System.Collections;

namespace Shopfloor.Master.Application.Validations.Structures
{
    public class CreateStructureCommandValidator : AbstractValidator<CreateStructureCommand>
    {
        private readonly IStructureRepository _structureRepository;
        public CreateStructureCommandValidator(IStructureRepository structureRepository)
        {
            _structureRepository = structureRepository;
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
            return await _structureRepository.IsUniqueAsync(code);
        }
    }
}
