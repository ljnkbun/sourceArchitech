using FluentValidation;
using Shopfloor.Master.Application.Command.Processes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Processes
{
    public class UpdateProcessCommandValidator : AbstractValidator<UpdateProcessCommand>
    {
        private readonly IProcessRepository _ProcessRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryGroupRepository _subCategoryGroupRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IDivisionRepository _divisionRepository;
        public UpdateProcessCommandValidator(IProcessRepository ProcessRepository, ISubCategoryGroupRepository subCategoryGroupRepository, ISubCategoryRepository subCategoryRepository, IProductGroupRepository productGroupRepository, ICategoryRepository categoryRepository, IDivisionRepository divisionRepository)
        {
            _ProcessRepository = ProcessRepository;
            _subCategoryGroupRepository = subCategoryGroupRepository;
            _subCategoryRepository = subCategoryRepository;
            _productGroupRepository = productGroupRepository;
            _categoryRepository = categoryRepository;
            _divisionRepository = divisionRepository;
            _ProcessRepository = ProcessRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion

            RuleFor(p => p.DivisionId)
                .MustAsync(IsExistDivisionAsync)
                .WithMessage("{PropertyName} not found.");

            RuleFor(p => p.CategoryId)
                .MustAsync(IsExistCategoryAsync)
                .WithMessage("{PropertyName} not found.");

            RuleFor(p => p.ProductGroupId)
                .MustAsync(IsExistProductGroupAsync)
                .WithMessage("{PropertyName} not found.");

            RuleFor(p => p.SubCategoryId)
                .MustAsync(IsExistSubCategoryAsync)
                .WithMessage("{PropertyName} not found.");

            RuleFor(p => p.SubCategoryGroupId)
                .MustAsync(IsExistSubCategoryGroupAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsUniqueAsync(UpdateProcessCommand command, CancellationToken token)
        {
            return await _ProcessRepository.IsUniqueAsync(command.Code,command.Id);
        }



        private async Task<bool> IsExistCategoryAsync(int? categoryId, CancellationToken token)
        {
            if (categoryId.HasValue)
            {
                return await _categoryRepository.IsExistAsync(categoryId.Value);
            }

            return true;
        }

        private async Task<bool> IsExistSubCategoryAsync(int? subCategoryId, CancellationToken token)
        {
            if (subCategoryId.HasValue)
            {
                return await _subCategoryRepository.IsExistAsync(subCategoryId.Value);
            }

            return true;
        }

        private async Task<bool> IsExistSubCategoryGroupAsync(int? subCategoryGroupId, CancellationToken token)
        {
            if (subCategoryGroupId.HasValue)
            {
                return await _subCategoryGroupRepository.IsExistAsync(subCategoryGroupId.Value);
            }

            return true;
        }

        private async Task<bool> IsExistProductGroupAsync(int? productGroupId, CancellationToken token)
        {
            if (productGroupId.HasValue)
            {
                return await _productGroupRepository.IsExistAsync(productGroupId.Value);
            }
            return true;
        }

        private async Task<bool> IsExistDivisionAsync(int? divisionId, CancellationToken token)
        {
            if (divisionId.HasValue)
            {
                return await _divisionRepository.IsExistAsync(divisionId.Value);
            }
            return true;
        }
    }
}
