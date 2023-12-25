using FluentValidation;
using Shopfloor.IED.Application.Command.ProcessTemplates;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.ProcessTemplates
{
    public class UpdateProcessTemplateCommandValidator : AbstractValidator<UpdateProcessTemplateCommand>
    {
        private readonly IProcessTemplateRepository _processTemplateRepository;
        public UpdateProcessTemplateCommandValidator(IProcessTemplateRepository ProcessTemplateRepository)
        {
            _processTemplateRepository = ProcessTemplateRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateProcessTemplateCommand command, CancellationToken token)
        {
            return await _processTemplateRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
