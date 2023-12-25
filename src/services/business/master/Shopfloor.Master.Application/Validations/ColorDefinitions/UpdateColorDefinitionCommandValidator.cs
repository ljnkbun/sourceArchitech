using FluentValidation;
using Shopfloor.Master.Application.Command.ColorCards;
using Shopfloor.Master.Application.Command.ColorDefinitions;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.ProductGroups
{
    public class UpdateColorDefinitionCommandValidator : AbstractValidator<UpdateColorDefinitionCommand>
    {
        private readonly IColorDefinitionRepository _colorDefinitionRepository;
        public UpdateColorDefinitionCommandValidator(IColorDefinitionRepository colorDefinitionRepository)
        {
            _colorDefinitionRepository = colorDefinitionRepository;
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


        private async Task<bool> IsUniqueAsync(UpdateColorDefinitionCommand command, CancellationToken cancellationToken)
        {
            return await _colorDefinitionRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
