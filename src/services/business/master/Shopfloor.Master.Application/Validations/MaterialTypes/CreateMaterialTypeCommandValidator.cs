using FluentValidation;
using Shopfloor.Master.Application.Command.MaterialTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.MaterialTypes
{
    public class CreateMaterialTypeCommandValidator : AbstractValidator<CreateMaterialTypeCommand>
    {
        private readonly IMaterialTypeRepository _materialTypeRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CreateMaterialTypeCommandValidator(IMaterialTypeRepository materialTypeRepository, ICategoryRepository categoryRepository)
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

            RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .MustAsync(IsExistCategory).WithMessage("{PropertyName} not exists");

            _materialTypeRepository = materialTypeRepository;
            _categoryRepository = categoryRepository;
        }
        private async Task<bool> IsExistCategory(int id, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetByIdAsync(id) != null;
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _materialTypeRepository.IsUniqueAsync(code);
        }
    }
}
