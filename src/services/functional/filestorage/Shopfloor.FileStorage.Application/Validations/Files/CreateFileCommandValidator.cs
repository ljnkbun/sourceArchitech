using FluentValidation;
using Shopfloor.FileStorage.Application.Command.Files;
using Shopfloor.FileStorage.Application.Definations;

namespace Shopfloor.FileStorage.Application.Validations.Files
{
    public class CreateFileCommandValidator : AbstractValidator<CreateFileCommand>
    {
        public CreateFileCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Extension)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Folder)
                .Must(Folder.Contains).WithMessage("Folder is not exist.");
        }
    }
}
