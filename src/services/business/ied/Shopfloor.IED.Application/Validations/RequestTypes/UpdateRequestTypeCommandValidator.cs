using FluentValidation;
using Shopfloor.IED.Application.Command.RequestTypes;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.RequestTypes
{
    public class UpdateRequestTypeCommandValidator : AbstractValidator<UpdateRequestTypeCommand>
    {
        private readonly IRequestTypeRepository _requestTypeRepository;
        public UpdateRequestTypeCommandValidator(IRequestTypeRepository requestTypeRepository)
        {
            _requestTypeRepository = requestTypeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Name must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateRequestTypeCommand command, CancellationToken token)
        {
            return await _requestTypeRepository.IsNameUniqueAsync(command.Name, command.Id);
        }
    }
}
