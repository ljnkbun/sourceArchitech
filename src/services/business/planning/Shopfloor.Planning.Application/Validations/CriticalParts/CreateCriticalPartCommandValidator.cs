using FluentValidation;
using Shopfloor.Planning.Application.Command.CriticalParts;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.CriticalParts
{
    public class CreateCriticalPartCommandValidator : AbstractValidator<CreateCriticalPartCommand>
    {
		private readonly ICriticalPartRepository _repository;
        public CreateCriticalPartCommandValidator(ICriticalPartRepository repository)
        {
			_repository = repository;

			RuleFor(p => p.Name)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.")
				.MustAsync(IsNameUniqueAsync).WithMessage("{PropertyName} must unique.");

			RuleFor(p => p.Color)
                .MaximumLength(50)
                .WithMessage("{PropertyName} must not exceed 50 characters.");

			RuleFor(p => p).Must(p => p.Priority >= 1).WithMessage("Priority must greater than or equal 1.");
		}
		private async Task<bool> IsNameUniqueAsync(string name, CancellationToken token)
		{
			return await _repository.IsNameUniqueAsync(name);
		}
	}
}
