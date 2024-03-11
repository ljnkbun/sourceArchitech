using FluentValidation;
using Shopfloor.Master.Application.Command.ProductGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.ProductGroups
{
    public class CreateProductGroupCommandValidator : AbstractValidator<CreateProductGroupCommand>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CreateProductGroupCommandValidator(IProductGroupRepository productGroupRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productGroupRepository = productGroupRepository;

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
            .MustAsync(IsExistCategory);
        }

        private async Task<bool> IsExistCategory(int id, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetByIdAsync(id) != null;
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _productGroupRepository.IsUniqueAsync(code);
        }
    }
}
