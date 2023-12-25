using FluentValidation;
using Shopfloor.Master.Application.Command.Structures;
using Shopfloor.Master.Application.Command.SubCategories;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.SubCategories
{
    public class UpdateSubCategoryCommandValidator : AbstractValidator<UpdateSubCategoryCommand>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        public UpdateSubCategoryCommandValidator(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.SubCategoryGroupId)
                .NotNull()
                .WithMessage("{PropertyName} must not Null.");

            RuleFor(p => p.ProductGroupId)
                .NotNull()
                .WithMessage("{PropertyName} must not Null.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            return await _subCategoryRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
