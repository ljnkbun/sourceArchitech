using FluentValidation;
using Shopfloor.IED.Application.Command.Requests;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.Requests
{
    public class UpdateRequestCommandValidator : AbstractValidator<UpdateRequestCommand>
    {
        private readonly IRequestRepository _RequestRepository;
        public UpdateRequestCommandValidator(IRequestRepository RequestRepository)
        {
            _RequestRepository = RequestRepository;

            RuleFor(p => p.RequestTypeId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
        }
    }
}
