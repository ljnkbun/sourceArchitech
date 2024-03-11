using FluentValidation;
using Shopfloor.Planning.Application.Query.MergeSplitPORs;

namespace Shopfloor.Planning.Application.Validations.MergeSplitPorDetail
{
    public class GetMergeSplitPorDetailQueryValidator : AbstractValidator<GetMergeSplitPORsQuery>
    {
        public GetMergeSplitPorDetailQueryValidator()
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
