using FluentValidation;
using FluentValidation.Results;
using Shopfloor.Barcode.Application.Command.ExportArticles;
using Shopfloor.Barcode.Application.Command.ExportDetails;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.ExportArticles
{
    public class CreateExportArticleCommandValidator : AbstractValidator<CreateExportArticleCommand>
    {
        private readonly IExportArticleRepository _exportArticleRepository;
        private readonly IExportDetailRepository _exportDetailRepository;

        public CreateExportArticleCommandValidator(IExportArticleRepository ExportArticleRepository, IExportDetailRepository ExportDetailRepository)
        {
            _exportArticleRepository = ExportArticleRepository;
            _exportDetailRepository = ExportDetailRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must Unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Color)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Size)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Quantity)
               .GreaterThan(0).WithMessage("{PropertyName} must null or greater than 0.");

            RuleFor(p => p.UOM)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.GDIType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.LotNo)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.DeliveryOC)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Note)
               .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

            RuleFor(p => p.SummaryOC)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Buyer)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.GDINo)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ExportDetails).CustomAsync(ValidateExportDetails);

            RuleForEach(p => p.ExportDetails).ChildRules(child =>
            {

                child.RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(x => x.ExportArticleId)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();

                child.RuleFor(x => x.Color)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.Size)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.UOM)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.Shade)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.OC)
                   .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(x => x.LotNo)
                   .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(x => x.Status)
                    .NotNull()
                    .IsInEnum().WithMessage("Value is not part of the enum.");

                child.RuleFor(x => x.Note)
                   .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");
            });

        }

        private async Task ValidateExportDetails(ICollection<CreateExportDetailCommand> collection, ValidationContext<CreateExportArticleCommand> context, CancellationToken token)
        {
            var exportDetails = await _exportDetailRepository.GetAllAsync();
            if (exportDetails.Select(p => p.Code).Except(collection.Select(p => p.Code)).Any())
            {
                var valids = new ValidationFailure("code", "Detail code must Unique.");
                context.AddFailure(string.Join(Environment.NewLine, valids));
            }
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _exportArticleRepository.IsUniqueAsync(code);
        }

    }
}
