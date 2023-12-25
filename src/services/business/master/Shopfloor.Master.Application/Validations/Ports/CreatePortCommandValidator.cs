using FluentValidation;
using Shopfloor.Master.Application.Command.Ports;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Ports
{
    public class CreatePortCommandValidator : AbstractValidator<CreatePortCommand>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IPortRepository _portRepository;

        public CreatePortCommandValidator(ICountryRepository countryRepository, IPortRepository portRepository)
        {
            _countryRepository = countryRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CountryId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(IsExistCountry);
            _portRepository = portRepository;
        }
        private async Task<bool> IsExistCountry(int id, CancellationToken cancellationToken)
        {
            return await _countryRepository.GetByIdAsync(id) != null;
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _portRepository.IsUniqueAsync(code);
        }
    }
}
