using FluentValidation;
using Shopfloor.Master.Application.Command.Lines;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Lines
{
    public class UpdateLineCommandValidator : AbstractValidator<UpdateLineCommand>
    {
        private readonly ILineRepository _structureRepository;
        public UpdateLineCommandValidator(ILineRepository structureRepository)
        {
            _structureRepository = structureRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(r => r.WFXLineId).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Worker).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.FactoryId).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ProcessId).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateLineCommand command, CancellationToken cancellationToken)
        {
            return await _structureRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
