using FluentValidation;
using Shopfloor.Master.Application.Command.SubCategoryGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.SubCategoryGroups
{
    public class CreateSubCategoryGroupCommandValidator : AbstractValidator<CreateSubCategoryGroupCommand>
    {
        private readonly ISubCategoryGroupRepository _subCategoryGroupRepository;
        public CreateSubCategoryGroupCommandValidator(ISubCategoryGroupRepository subCategoryGroupRepository)
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
            _subCategoryGroupRepository = subCategoryGroupRepository;
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _subCategoryGroupRepository.IsUniqueAsync(code);
        }
    }
}
