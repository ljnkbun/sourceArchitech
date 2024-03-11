using FluentValidation;
using FluentValidation.Results;
using Shopfloor.Inspection.Application.Command.AQLs;
using Shopfloor.Inspection.Application.Command.AQLVersions;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Validations.AQLVersions
{
    public class UpdateAQLVersionCommandValidator : AbstractValidator<UpdateAQLVersionCommand>
    {
        private readonly IAQLVersionRepository _repository;
        public UpdateAQLVersionCommandValidator(IAQLVersionRepository repository)
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
            RuleFor(p => p.AQLs).Custom(Validate);
        }
        private void Validate(ICollection<UpdateAQLCommand> collection, ValidationContext<UpdateAQLVersionCommand> context)
        {
            var list = collection.OrderBy(x => x.LotSizeFrom).ToList();
            var prevVal = list.First().LotSizeTo;
            for (int i = 1; i < list.Count; i++)
            {
                var expectedVal = prevVal + 1;
                if (list[i].LotSizeFrom != expectedVal)
                {
                    var valids = new ValidationFailure("LotSizeFrom", "Invalid LotSizeFrom ");
                    context.AddFailure(string.Join(Environment.NewLine, valids));
                    return;
                }
                prevVal = list[i].LotSizeTo;
            }
        }
        private async Task<bool> IsUniqueAsync(UpdateAQLVersionCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
