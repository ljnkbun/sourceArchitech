using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingIEDs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.WeavingIEDs
{
    public class CreateWeavingIEDCommandValidator : AbstractValidator<CreateWeavingIEDCommand>
    {
        private readonly IRequestTypeRepository _requestType;

        public CreateWeavingIEDCommandValidator(IRequestTypeRepository requestType)
        {
            _requestType = requestType;
            RuleFor(p => p.ArticleCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ArticleName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ProductGroup)
               .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.SubCategory)
               .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Buyer)
               .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.RequestNo)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.RequestTypeId)
                .MustAsync(IsExistRequestTypeAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistRequestTypeAsync(int? requestTypeId, CancellationToken token)
        {
            return requestTypeId != null && await _requestType.IsExistAsync(requestTypeId.Value);
        }
    }
}
