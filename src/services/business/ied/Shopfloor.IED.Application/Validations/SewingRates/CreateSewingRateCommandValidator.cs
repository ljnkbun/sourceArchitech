using FluentValidation;
using Shopfloor.IED.Application.Command.SewingRates;

namespace Shopfloor.IED.Application.Validations.SewingRates
{
    public class CreateSewingRateCommandValidator : AbstractValidator<CreateSewingRateCommand>
    {
        public CreateSewingRateCommandValidator()
        {
            RuleFor(p => p).Must(p => p.ExpectedQtyFrom >= 0).WithMessage("ExpectedQtyFrom must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.ExpectedQtyTo >= p.ExpectedQtyFrom).WithMessage("ExpectedQtyTo must greater than or equal ExpectedQtyFrom.");
            RuleFor(p => p).Must(p => p.EfficiencyRate >= 0 && p.EfficiencyRate <= 1).WithMessage("EfficiencyRate must from 0 to 1.");
            RuleFor(p => p).Must(p => p.CMRate >= 0 && p.CMRate <= 1).WithMessage("CMRate must from 0 to 1.");
        }
    }
}
