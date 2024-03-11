using FluentValidation;
using Shopfloor.Inspection.Application.Query.QCRequests;

namespace Shopfloor.Inspection.Application.Validations.QCRequests
{
    public class GetQCRequestsQueryValidator : AbstractValidator<GetQCRequestsQuery>
    {
        public GetQCRequestsQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));
            RuleFor(p => p.SiteCode).MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.SiteName).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.SupplierName).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.QCRequestNo).MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.Category).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.DocumentNo).MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.QCDefinitionCode).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        }
    }
}
