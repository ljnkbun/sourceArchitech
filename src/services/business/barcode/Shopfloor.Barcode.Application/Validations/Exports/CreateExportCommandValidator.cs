using FluentValidation;
using FluentValidation.Results;
using Shopfloor.Barcode.Application.Command.ExportArticles;
using Shopfloor.Barcode.Application.Command.Exports;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.Exports
{
    public class CreateExportCommandValidator : AbstractValidator<CreateExportCommand>
    {
        private readonly IWfxGDIRepository _wfxGDIRepository;
        private readonly IExportDetailRepository _exportDetailRepository;
        private readonly IExportArticleRepository _exportArticleRepository;

        public CreateExportCommandValidator(
             IWfxGDIRepository wfxGDIRepository
            , IExportDetailRepository exportDetailRepository
            , IExportArticleRepository exportArticleRepository
            )
        {
            _wfxGDIRepository = wfxGDIRepository;
            _exportDetailRepository = exportDetailRepository;
            _exportArticleRepository = exportArticleRepository;
            RuleFor(p => p.Name)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Status)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.Note)
               .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

            RuleFor(p => p.ExportArticles).CustomAsync(ValidateExportArticle);

            RuleForEach(p => p.ExportArticles).ChildRules(child =>
            {
                child.RuleFor(x => x.ArticleName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(x => x.ColorCode)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.SizeCode)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.Quantity)
                   .GreaterThan(0).WithMessage("{PropertyName} must null or greater than 0.");

                child.RuleFor(x => x.UOM)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.GDIType)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .IsInEnum().WithMessage("Value is not part of the enum.");

                child.RuleFor(x => x.LocationId)
                     .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();

                child.RuleFor(x => x.DeliveryOC)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.Note)
                   .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

                child.RuleFor(x => x.DeliveryOC)
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(x => x.Buyer)
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(x => x.GDINum)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            });
        }

        private async Task ValidateExportArticle(ICollection<CreateExportArticleCommand> collection, ValidationContext<CreateExportCommand> context, CancellationToken token)
        {
            var exportArticles = await _exportArticleRepository.GetAllAsync();

            var exportDetails = await _exportDetailRepository.GetAllAsync();
            if (exportDetails.Any())
            {
                foreach (var article in collection)
                {
                    if (article.ExportDetails.Any(x => x.ArticleCode != article.ArticleCode))
                    {
                        var valids = new ValidationFailure("ArticleCode", "Not Create Detail difference from ArticleCode");
                        context.AddFailure(string.Join(Environment.NewLine, valids));
                    }
                    var notHasLasDetailLst = article.ExportDetails.Take(article.ExportDetails.Count - 1);
                    if (notHasLasDetailLst.Sum(x => x.Quantity) > article.Quantity)
                    {
                        var valids = new ValidationFailure("Quantity", "Detail quantity over than Article quantity");
                        context.AddFailure(string.Join(Environment.NewLine, valids));
                    }
                }


                var wfxGDIs = await _wfxGDIRepository.GetByArticleCodesAsync(exportArticles.Select(x => x.ArticleCode).ToArray());
                foreach (var detail in collection.SelectMany(x => x.ExportDetails))
                {
                    var wfxGDI = wfxGDIs.FirstOrDefault(x => x.ArticleCode == detail.ArticleCode && x.RollBarcode == detail.Barcode);
                    if (wfxGDI != null)
                    {
                        if (detail.ColorCode != wfxGDI.ColorCode)
                        {
                            var valids = new ValidationFailure("Color", "Invalid Detail ColorCode");
                            context.AddFailure(string.Join(Environment.NewLine, valids));
                        }
                        if (detail.SizeCode != wfxGDI.SizeCode)
                        {
                            var valids = new ValidationFailure("Size", "Invalid Detail SizeCode");
                            context.AddFailure(string.Join(Environment.NewLine, valids));
                        }
                        if (detail.Shade != wfxGDI.Shade)
                        {
                            var valids = new ValidationFailure("Shade", "Invalid Detail Shade");
                            context.AddFailure(string.Join(Environment.NewLine, valids));
                        }
                        if (detail.UOM != wfxGDI.UOM)
                        {
                            var valids = new ValidationFailure("UOM", "Invalid Detail UOM");
                            context.AddFailure(string.Join(Environment.NewLine, valids));
                        }

                        if (detail.Quantity > wfxGDI.RollUnits)
                        {
                            var valids = new ValidationFailure("Quantity", "Invalid Detail RollUnits");
                            context.AddFailure(string.Join(Environment.NewLine, valids));
                        }
                    }
                }
            }
        }

    }
}
