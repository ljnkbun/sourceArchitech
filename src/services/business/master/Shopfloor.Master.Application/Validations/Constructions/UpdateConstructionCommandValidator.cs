using FluentValidation;
using Shopfloor.Master.Application.Command.CompanyCurrencies;
using Shopfloor.Master.Application.Command.Constructions;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Constructions
{
    public class UpdateConstructionCommandValidator : AbstractValidator<UpdateConstructionCommand>
    {
        private readonly IConstructionRepository _constructionRepository;
        public UpdateConstructionCommandValidator(IConstructionRepository constructionRepository)
        {
            _constructionRepository = constructionRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateConstructionCommand command, CancellationToken cancellationToken)
        {
            return await _constructionRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
