using FluentValidation;
using Shopfloor.Master.Application.Command.GroupNames;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.GroupNames
{
    public class CreateGroupNameCommandValidator : AbstractValidator<CreateGroupNameCommand>
    {
        private readonly IGroupNameRepository _groupNameRepository;
        public CreateGroupNameCommandValidator(IGroupNameRepository groupNameRepository)
        {
            _groupNameRepository = groupNameRepository;

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
            return await _groupNameRepository.IsUniqueAsync(code);
        }
    }
}
