using FluentValidation;
using Shopfloor.Planning.Application.Query.StripFactoryScheduleDetails;

namespace Shopfloor.Planning.Application.Validations.StripFactoryScheduleDetails
{
    public class GetStripFactoryScheduleDetailsQueryValidator : AbstractValidator<GetStripFactoryScheduleDetailsQuery>
    {
        public GetStripFactoryScheduleDetailsQueryValidator()
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
