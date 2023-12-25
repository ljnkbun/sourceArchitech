using FluentValidation;
using Shopfloor.IED.Application.Command.RequestTypes;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.RequestTypes
{
    public class CreateRequestTypeCommandValidator : AbstractValidator<CreateRequestTypeCommand>
    {
        private readonly IRequestTypeRepository _requestTypeRepository;
        public CreateRequestTypeCommandValidator(IRequestTypeRepository requestTypeRepository)
        {
            _requestTypeRepository = requestTypeRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _requestTypeRepository.IsUniqueAsync(code);
        }
    }
}
