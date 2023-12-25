using FluentValidation;
using Shopfloor.Master.Application.Command.Grades;
using Shopfloor.Master.Application.Command.GroupNames;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.GroupNames
{
    public class UpdateGroupNameCommandValidator : AbstractValidator<UpdateGroupNameCommand>
    {
        private readonly IGroupNameRepository _groupNameRepository;
        public UpdateGroupNameCommandValidator(IGroupNameRepository groupNameRepository)
        {
            _groupNameRepository = groupNameRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateGroupNameCommand command, CancellationToken cancellationToken)
        {
            return await _groupNameRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
