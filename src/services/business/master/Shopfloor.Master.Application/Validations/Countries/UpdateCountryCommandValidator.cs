using FluentValidation;
using Shopfloor.Master.Application.Command.Constructions;
using Shopfloor.Master.Application.Command.Countries;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Countries
{
    public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
    {
        private readonly ICountryRepository _countryRepository;
        public UpdateCountryCommandValidator(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateCountryCommand command, CancellationToken cancellationToken)
        {
            return await _countryRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
