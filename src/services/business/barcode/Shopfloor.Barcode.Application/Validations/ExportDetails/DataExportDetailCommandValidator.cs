using FluentValidation;
using Shopfloor.Barcode.Application.Models.ExportDetails;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.ExportDetails
{
    public class DataExportDetailCommandValidator : AbstractValidator<ExportDetailExcelModel>
    {
        private readonly IExportDetailRepository _repository;

        public DataExportDetailCommandValidator(IExportDetailRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters."); 
            
            RuleFor(p => p.Color)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Size)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Shade)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.QtyMet)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.QtyUnit)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.QtyYard)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.OC)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Note)
               .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(code);
        }
    }
}