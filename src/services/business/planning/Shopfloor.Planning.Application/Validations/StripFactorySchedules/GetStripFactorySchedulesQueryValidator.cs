using FluentValidation;
using Shopfloor.Planning.Application.Query.StripFactorySchedules;

namespace Shopfloor.Planning.Application.Validations.StripFactorySchedules
{
    public class GetStripFactorySchedulesQueryValidator : AbstractValidator<GetStripFactorySchedulesQuery>
    {
        public GetStripFactorySchedulesQueryValidator()
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
