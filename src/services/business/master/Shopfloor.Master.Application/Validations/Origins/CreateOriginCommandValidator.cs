using FluentValidation;
using Shopfloor.Master.Application.Command.Origins;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Origins
{
    public class CreateOriginCommandValidator : AbstractValidator<CreateOriginCommand>
    {
        private readonly IOriginRepository _originRepository;
        public CreateOriginCommandValidator(IOriginRepository originRepository)
        {
            _originRepository = originRepository;
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
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _originRepository.IsUniqueAsync(code);
        }
    }
}
