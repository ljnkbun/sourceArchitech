using FluentValidation;
using Shopfloor.Master.Application.Command.ProductGroups;
using Shopfloor.Master.Application.Command.UOMConversions;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.UOMConversions
{
    public class UpdateUOMConversionCommandValidator : AbstractValidator<UpdateUOMConversionCommand>
    {
        private readonly IUOMConversionRepository _repository;
        public UpdateUOMConversionCommandValidator(IUOMConversionRepository repository)
        {

            RuleFor(p => p.Value)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0");

            RuleFor(p => p.FromUOMId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0");

            RuleFor(p => p.ToUOMId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0");

            RuleFor(p => p.Action)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            _repository = repository;

        }

    }
}
