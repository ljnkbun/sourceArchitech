using FluentValidation;
using Shopfloor.Inspection.Application.Query.Attachments;

namespace Shopfloor.Inspection.Application.Validations.Attachments
{
    public class GetAttachmentsQueryValidator : AbstractValidator<GetAttachmentsQuery>
    {
        public GetAttachmentsQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));
            			RuleFor(p => p.FileName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.Description).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.FileId).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        }
    }
}
