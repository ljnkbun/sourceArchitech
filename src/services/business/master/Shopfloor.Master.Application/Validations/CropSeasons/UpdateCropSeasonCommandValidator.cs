using FluentValidation;
using Shopfloor.Master.Application.Command.CountTypes;
using Shopfloor.Master.Application.Command.CropSeasons;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.CropSeasons
{
    public class UpdateCropSeasonCommandValidator : AbstractValidator<UpdateCropSeasonCommand>
    {
        private readonly ICropSeasonRepository _cropSeasonRepository;
        public UpdateCropSeasonCommandValidator(ICropSeasonRepository cropSeasonRepository)
        {
            _cropSeasonRepository = cropSeasonRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateCropSeasonCommand command, CancellationToken cancellationToken)
        {
            return await _cropSeasonRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
