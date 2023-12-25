using FluentValidation;
using Shopfloor.Master.Application.Query.MaterialTypeMapProductGroups;

namespace Shopfloor.Master.Application.Validations.MaterialTypeMapProductGroups
{
    public class GetMaterialTypeMapProductGroupsQueryValidator : AbstractValidator<GetMaterialTypeMapProductGroupsQuery>
    {
        public GetMaterialTypeMapProductGroupsQueryValidator()
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
