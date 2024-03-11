using FluentValidation;
using Shopfloor.Master.Application.Command.MaterialTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.MaterialTypes
{
    public class CreateMaterialTypeCommandValidator : AbstractValidator<CreateMaterialTypeCommand>
    {
        private readonly IMaterialTypeRepository _materialTypeRepository;

        public CreateMaterialTypeCommandValidator(IMaterialTypeRepository materialTypeRepository)
        {

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            _materialTypeRepository = materialTypeRepository;
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _materialTypeRepository.IsUniqueAsync(code);
        }
    }
}
