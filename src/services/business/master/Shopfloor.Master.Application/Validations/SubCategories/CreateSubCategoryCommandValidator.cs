using FluentValidation;
using Shopfloor.Master.Application.Command.SubCategories;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.SubCategories
{
    public class CreateSubCategoryCommandValidator : AbstractValidator<CreateSubCategoryCommand>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly ISubCategoryGroupRepository _subCategoryGroupRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        public CreateSubCategoryCommandValidator(IProductGroupRepository productGroupRepository, ISubCategoryGroupRepository subCategoryGroupRepository, ISubCategoryRepository subCategoryRepository)
        {
            _productGroupRepository = productGroupRepository;
            _subCategoryGroupRepository = subCategoryGroupRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.SubCategoryGroupId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(IsExistSubCategoryGroup);

            RuleFor(p => p.ProductGroupId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(IsExistProductGroup);
            _subCategoryRepository = subCategoryRepository;
        }

        private async Task<bool> IsExistProductGroup(int id, CancellationToken cancellationToken)
        {
            return await _productGroupRepository.GetByIdAsync(id) != null;
        }
        private async Task<bool> IsExistSubCategoryGroup(int id, CancellationToken cancellationToken)
        {
            return await _subCategoryGroupRepository.GetByIdAsync(id) != null;
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _subCategoryRepository.IsUniqueAsync(code);
        }
    }
}
