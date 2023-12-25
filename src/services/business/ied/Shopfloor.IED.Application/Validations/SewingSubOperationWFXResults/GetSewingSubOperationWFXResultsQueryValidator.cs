using FluentValidation;
using Shopfloor.IED.Application.Query.SewingSubOperationWFXResults;

namespace Shopfloor.IED.Application.Validations.SewingSubOperationWFXResults
{
    public class GetSewingSubOperationWFXResultsQueryValidator : AbstractValidator<GetSewingSubOperationWFXResultsQuery>
    {
        public GetSewingSubOperationWFXResultsQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
