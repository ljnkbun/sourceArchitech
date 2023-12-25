using FluentValidation;
using Shopfloor.Barcode.Application.Command.Imports;
using Shopfloor.Barcode.Application.Validations.ImportArticles;

namespace Shopfloor.Barcode.Application.Validations.Imports
{
    public class UpdateImportCommandValidator : AbstractValidator<UpdateImportCommand>
    {
        public UpdateImportCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("{PropertyName} must null or greater than 0.");
            RuleFor(p => p.Code).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleForEach(x => x.ImportArticles).SetValidator(new UpdateImportArticleCommandValidator());
        }
        
    }
}
