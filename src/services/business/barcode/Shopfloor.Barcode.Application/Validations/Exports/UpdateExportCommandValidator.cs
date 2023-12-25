using FluentValidation;
using Shopfloor.Barcode.Application.Command.Exports;
using Shopfloor.Barcode.Application.Validations.ExportArticles;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.Exports
{
    public class UpdateExportCommandValidator : AbstractValidator<UpdateExportCommand>
    {

        public UpdateExportCommandValidator()
        {

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.Note)
            .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

            RuleForEach(x => x.ExportArticles).SetValidator(new UpdateExportArticleCommandValidator());

        }

    }
}
