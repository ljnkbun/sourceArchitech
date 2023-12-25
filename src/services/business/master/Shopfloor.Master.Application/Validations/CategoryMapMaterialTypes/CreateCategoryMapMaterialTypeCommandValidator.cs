using FluentValidation;
using Shopfloor.Master.Application.Command.CategoryMapMaterialTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.CategoryMapMaterialTypes
{
    public class CreateCategoryMapMaterialTypeCommandValidator : AbstractValidator<CreateCategoryMapMaterialTypeCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMaterialTypeRepository _materialTypeRepository;
        private readonly ICategoryMapMaterialTypeRepository _categoryMapMaterialTypeRepository;
        public CreateCategoryMapMaterialTypeCommandValidator(ICategoryRepository categoryRepository, IMaterialTypeRepository materialTypeRepository, ICategoryMapMaterialTypeRepository categoryMapMaterialTypeRepository)
        {
            _categoryRepository = categoryRepository;
            _materialTypeRepository = materialTypeRepository;
            _categoryMapMaterialTypeRepository = categoryMapMaterialTypeRepository;

            RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .MustAsync(IsExistCategory);

            RuleFor(p => p.MaterialTypeId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .MustAsync(IsExistMaterialType);

            RuleFor(p => p)
            .MustAsync(IsDuplicateAsync).WithMessage("Data exists");

        }

        private async Task<bool> IsDuplicateAsync(CreateCategoryMapMaterialTypeCommand command, CancellationToken cancellationToken)
        {
            return await _categoryMapMaterialTypeRepository.IsDuplicateAsync(command.CategoryId, command.MaterialTypeId);
        }
        private async Task<bool> IsExistCategory(int id, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetByIdAsync(id) != null;
        }
        private async Task<bool> IsExistMaterialType(int id, CancellationToken cancellationToken)
        {
            return await _materialTypeRepository.GetByIdAsync(id) != null;
        }

    }
}
