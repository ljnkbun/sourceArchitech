using FluentValidation;
using FluentValidation.Results;
using Shopfloor.Barcode.Application.Command.ExportArticles;
using Shopfloor.Barcode.Application.Command.Exports;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.Exports
{
    public class CreateExportCommandValidator : AbstractValidator<CreateExportCommand>
    {
        private readonly IExportRepository _exportRepository;
        private readonly IExportArticleRepository _exportArticleRepository;
        private readonly IExportDetailRepository _exportDetailRepository;

        public CreateExportCommandValidator(IExportRepository ExportRepository, IExportArticleRepository ExportArticleRepository, IExportDetailRepository ExportDetailRepository)
        {
            _exportRepository = ExportRepository;
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

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.Note)
               .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

            RuleFor(p => p.ExportArticles).CustomAsync(ValidateExportArticle);

            RuleForEach(p => p.ExportArticles).ChildRules(child =>
            {
                child.RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(x => x.Color)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.Size)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.Quantity)
                   .GreaterThan(0).WithMessage("{PropertyName} must null or greater than 0.");

                child.RuleFor(x => x.UOM)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");


                child.RuleFor(x => x.GDIType)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .IsInEnum().WithMessage("Value is not part of the enum.");

                child.RuleFor(x => x.LotNo)
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(x => x.DeliveryOC)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.Note)
                   .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

                child.RuleFor(x => x.DeliveryOC)
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(x => x.Buyer)
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(x => x.GDINo)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            });

        }

        private async Task ValidateExportArticle(ICollection<CreateExportArticleCommand> collection, ValidationContext<CreateExportCommand> context, CancellationToken token)
        {
            var exportArticles = await _exportArticleRepository.GetAllAsync();
            if (exportArticles.Select(p => p.Code).Except(collection.Select(p => p.Code)).Any())
            {
                var valids = new ValidationFailure("code", "Article code must Unique.");
                context.AddFailure(string.Join(Environment.NewLine, valids));
            }

            var exportDetails = await _exportDetailRepository.GetAllAsync();
            if (exportDetails.Select(p => p.Code).Except(collection.Select(p => p.ExportDetails.SelectMany(x=>x.Code))).Any())
            {
                var valids = new ValidationFailure("code", "Detail code must Unique.");
                context.AddFailure(string.Join(Environment.NewLine, valids));
            }
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _exportRepository.IsUniqueAsync(code);
        }


    }
}
