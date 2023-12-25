using FluentValidation;
using Shopfloor.IED.Application.Command.Requests;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.Requests
{
    public class CreateRequestCommandValidator : AbstractValidator<CreateRequestCommand>
    {
        private readonly IRequestRepository _requestRepository;
        public CreateRequestCommandValidator(IRequestRepository RequestRepository)
        {
            _requestRepository = RequestRepository;

            RuleFor(p => p.RequestTypeId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

        }
    }
}
