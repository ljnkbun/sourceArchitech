using FluentValidation;
using Shopfloor.Master.Application.Command.Structures;
using Shopfloor.Master.Application.Command.SubCategories;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.SubCategories
{
    public class UpdateSubCategoryCommandValidator : AbstractValidator<UpdateSubCategoryCommand>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly ISubCategoryGroupRepository _subCategoryGroupRepository;
        public UpdateSubCategoryCommandValidator(ISubCategoryRepository subCategoryRepository, IProductGroupRepository productGroupRepository, ISubCategoryGroupRepository subCategoryGroupRepository)
        {
            _subCategoryRepository = subCategoryRepository;
            _productGroupRepository = productGroupRepository;
            _subCategoryGroupRepository = subCategoryGroupRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion

            RuleFor(p => p.ProductGroupId)
                .MustAsync(IsExistProductGroup).WithMessage("{PropertyName} not found.");

            RuleFor(p => p.SubCategoryGroupId)
                .MustAsync(IsExistSubCategoryGroup).WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsUniqueAsync(UpdateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            return await _subCategoryRepository.IsUniqueAsync(command.Code, command.Id);
        }

        private async Task<bool> IsExistProductGroup(int id, CancellationToken cancellationToken)
        {
            return await _productGroupRepository.IsExistAsync(id);
        }
        private async Task<bool> IsExistSubCategoryGroup(int? id, CancellationToken cancellationToken)
        {
            if (id.HasValue)
            {
                return await _subCategoryGroupRepository.IsExistAsync(id.Value);
            }

            return true;
        }
    }
}
