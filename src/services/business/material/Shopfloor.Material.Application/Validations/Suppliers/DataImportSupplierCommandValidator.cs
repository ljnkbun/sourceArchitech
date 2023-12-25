using FluentValidation;
using Shopfloor.Material.Application.Models.Suppliers;

namespace Shopfloor.Material.Application.Validations.Suppliers
{
    public class DataImportSupplierCommandValidator : AbstractValidator<SupplierImportExcelModel>
    {
        public DataImportSupplierCommandValidator()
        {
            RuleFor(p => p.CompanyId)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ShortName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Address)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.BillAddress)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ShipAddress)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.City)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.State)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.ZipCode)
                .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters.");

            RuleFor(p => p.CountryName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Telephone)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.CurrencyName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.ContactFirstName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.ContactLastName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Email)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.BusinessSegment)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ProductCategory)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.PaymentTerms)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.DeliveryTerms)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ShipmentTerms)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.CountryOfOrigin)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.PortOfLoading)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.GroupName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.GroupNameCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.CatalogPath)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.AccountGroupName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.BankAccountNumber)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.BankAddressDetails)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CompanyWebsite)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.SupplierTypeName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.VATNumber)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        }
    }
}