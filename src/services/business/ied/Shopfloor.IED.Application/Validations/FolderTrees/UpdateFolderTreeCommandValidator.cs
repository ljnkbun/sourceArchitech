using FluentValidation;
using Shopfloor.IED.Application.Command.FolderTrees;

namespace Shopfloor.IED.Application.Validations.FolderTrees
{
    public class UpdateFolderTreeCommandValidator : AbstractValidator<UpdateFolderTreeCommand>
    {
        public UpdateFolderTreeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
    }
}
