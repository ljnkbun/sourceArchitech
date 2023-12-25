﻿using FluentValidation;
using Shopfloor.Barcode.Application.Command.ImportTransferToSiteSyns;

namespace Shopfloor.Barcode.Application.Validations.ImportTransferToSiteDetails
{
    public class CreateImportTransferToSiteSyncCommandValidator : AbstractValidator<CreateImportTransferToSiteSyncCommand>
    {
        public CreateImportTransferToSiteSyncCommandValidator()
        {
            RuleFor(r => r.ArticleName).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ArticleCode).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Color).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.UOM).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.StoringUOM).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.GDNNo).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.FromSite).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ToSite).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.OC).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.LotNo).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Qty).GreaterThan(0).WithMessage("{PropertyName}  is required.");
          
        }
    }
}
