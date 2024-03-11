using FluentValidation;
using Shopfloor.Inspection.Application.Command.QCDefects;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Validations.QCDefects
{
    public class UpdateQCDefectCommandValidator : AbstractValidator<UpdateQCDefectCommand>
    {
        private readonly IQCDefectRepository _repository;
        public UpdateQCDefectCommandValidator(IQCDefectRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
            RuleFor(r => r.QCDefecTypeId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(p => p.NameEN).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.DivisonName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.ProcessName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.CategoryName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.SubCategoryId).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.SubCategoryName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        }
        private async Task<bool> IsUniqueAsync(UpdateQCDefectCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
