using FluentValidation;
using Shopfloor.Master.Application.Query.CategoryMapMaterialTypes;

namespace Shopfloor.Master.Application.Validations.CategoryMapMaterialTypes
{
    public class GetCategoryMapMaterialTypesQueryValidator : AbstractValidator<GetCategoryMapMaterialTypesQuery>
    {
        public GetCategoryMapMaterialTypesQueryValidator()
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
