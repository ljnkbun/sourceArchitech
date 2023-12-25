using FluentValidation;
using Shopfloor.IED.Application.Command.FolderTrees;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.FolderTrees
{
    public class CreateFolderTreeCommandValidator : AbstractValidator<CreateFolderTreeCommand>
    {
        public CreateFolderTreeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ItemType).IsInEnum();
            RuleFor(p => p.DivisionType).IsInEnum();
        }
    }
}
