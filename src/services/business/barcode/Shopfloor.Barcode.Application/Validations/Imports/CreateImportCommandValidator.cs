using FluentValidation;
using FluentValidation.Results;
using Shopfloor.Barcode.Application.Command.ImportArticles;
using Shopfloor.Barcode.Application.Command.Imports;
using Shopfloor.Barcode.Application.Validations.ImportArticles;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.Imports
{
    public class CreateImportCommandValidator : AbstractValidator<CreateImportCommand>
    {
        private readonly IWfxPOArticleRepository _wfxPOArticleRepository;
        private readonly IWfxGDNRepository _wfxGDNRepository;

        public CreateImportCommandValidator(
             IWfxPOArticleRepository wfxPOArticleRepository
            , IWfxGDNRepository wfxGDNRepository
            )
        {
            _wfxPOArticleRepository = wfxPOArticleRepository;
            _wfxGDNRepository = wfxGDNRepository;

            RuleFor(p => p.Status)
                .IsInEnum().WithMessage("{PropertyName} must be Enum .");

            RuleFor(p => p.Type)
                .IsInEnum().WithMessage("{PropertyName} must be Enum .");

            RuleForEach(x => x.ImportArticles).SetValidator(new CreateImportArticleCommandValidator());

            RuleFor(p => p.ImportArticles).CustomAsync(ValidateImportArticle);
        }

        private async Task ValidateImportArticle(ICollection<CreateImportArticleCommand> collection, ValidationContext<CreateImportCommand> context, CancellationToken token)
        {

            if (context.InstanceToValidate.Type == Domain.Constants.ImportType.ImportPO)
            {
                var wfxPOArticles = await _wfxPOArticleRepository.GetByOrderRefsAsync(collection.Select(x => x.OrderRefNum).ToArray());

                foreach (var detail in collection.SelectMany(x => x.ImportDetails))
                {
                    var wfxPOArticle = wfxPOArticles.FirstOrDefault(x => x.ArticleCode == detail.ArticleCode && x.ColorCode == detail.Color && x.SizeCode == detail.Size);
                    if (wfxPOArticle != null)
                    {
                        if (detail.Color != wfxPOArticle.ColorCode)
                        {
                            var valids = new ValidationFailure("Color", "Invalid Detail ColorCode");
                            context.AddFailure(string.Join(Environment.NewLine, valids));
                        }
                        if (detail.Size != wfxPOArticle.SizeCode)
                        {
                            var valids = new ValidationFailure("Size", "Invalid Detail SizeCode");
                            context.AddFailure(string.Join(Environment.NewLine, valids));
                        }
                        if (detail.Quantity > wfxPOArticle.Quantity)
                        {
                            var valids = new ValidationFailure("Quantity", "Invalid Detail Quantity");
                            context.AddFailure(string.Join(Environment.NewLine, valids));
                        }
                    }   
                }
            }
            else if (context.InstanceToValidate.Type == Domain.Constants.ImportType.ImportTransferToSite)
            {
                var wfxGDNs = await _wfxGDNRepository.GetByArticleCodeGDNNumAsync(collection.FirstOrDefault()?.ArticleCode, collection.FirstOrDefault()?.GDNNumber);

                foreach (var detail in collection.SelectMany(x => x.ImportDetails))
                {
                    var wfxGDN = wfxGDNs.FirstOrDefault();
                    if (wfxGDN != null)
                    {
                        if (detail.Color != wfxGDN.ColorCode)
                        {
                            var valids = new ValidationFailure("Color", "Invalid Detail ColorCode");
                            context.AddFailure(string.Join(Environment.NewLine, valids));
                        }
                        if (detail.Size != wfxGDN.SizeCode)
                        {
                            var valids = new ValidationFailure("Size", "Invalid Detail SizeCode");
                            context.AddFailure(string.Join(Environment.NewLine, valids));
                        }
                        if (detail.Quantity > wfxGDN.RollUnits)
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
