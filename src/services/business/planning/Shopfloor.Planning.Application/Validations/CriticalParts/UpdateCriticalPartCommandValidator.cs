using FluentValidation;
using Shopfloor.Planning.Application.Command.CriticalParts;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.CriticalParts
{   
    public class UpdateCriticalPartCommandValidator : AbstractValidator<UpdateCriticalPartCommand>
    {
		private readonly ICriticalPartRepository _repository;
		public UpdateCriticalPartCommandValidator(ICriticalPartRepository repository)
        {
			_repository = repository;

			RuleFor(p => p.Name)
				.MaximumLength(250)
				.WithMessage("{PropertyName} must not exceed 250 characters.");

			RuleFor(p => p.Color)
				.MaximumLength(50)
				.WithMessage("{PropertyName} must not exceed 50 characters.");

			RuleFor(p => p).Must(p => p.Priority >= 1).WithMessage("Priority must greater than or equal 1.");
			RuleFor(p => p).MustAsync(IsNameUniqueAsync).WithMessage("Name must unique.");
		}
		private async Task<bool> IsNameUniqueAsync(UpdateCriticalPartCommand command, CancellationToken token)
		{
			return await _repository.IsNameUniqueAsync(command.Name, command.Id);
		}	
	}
}
