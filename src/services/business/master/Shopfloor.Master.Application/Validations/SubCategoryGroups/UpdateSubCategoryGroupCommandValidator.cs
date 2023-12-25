using FluentValidation;
using Shopfloor.Master.Application.Command.SubCategories;
using Shopfloor.Master.Application.Command.SubCategoryGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.SubCategoryGroups
{
    public class UpdateSubCategoryGroupCommandValidator : AbstractValidator<UpdateSubCategoryGroupCommand>
    {
        private readonly ISubCategoryGroupRepository _subCategoryGroupRepository;
        public UpdateSubCategoryGroupCommandValidator(ISubCategoryGroupRepository subCategoryGroupRepository)
        {
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
        }

        private async Task<bool> IsUniqueAsync(UpdateSubCategoryGroupCommand command, CancellationToken cancellationToken)
        {
            return await _subCategoryGroupRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
