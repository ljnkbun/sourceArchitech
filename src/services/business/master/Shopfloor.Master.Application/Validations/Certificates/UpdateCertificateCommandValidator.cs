using FluentValidation;
using NPOI.SS.Formula.Functions;
using Shopfloor.Master.Application.Command.Certificates;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Certificate
{
    public class UpdateCertificateCommandValidator : AbstractValidator<UpdateCertificateCommand>
    {
        private readonly ICertificateRepository _certificateRepository;
        public UpdateCertificateCommandValidator(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateCertificateCommand command, CancellationToken token)
        {
            return await _certificateRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
