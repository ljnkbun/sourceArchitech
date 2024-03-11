using FluentValidation;
using Shopfloor.IED.Application.Command.KnittingGreiges;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.KnittingGreiges
{
    public class CreateKnittingGreigeCommandValidator : AbstractValidator<CreateKnittingGreigeCommand>
    {
        public CreateKnittingGreigeCommandValidator()
        {
            RuleFor(p => p).Must(p => p.Width >= 0).WithMessage("Width must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.WidthLossRate >= 0).WithMessage("WidthLossRate must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.WeightGM >= 0).WithMessage("WeightGM must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.WeightGMLossRate >= 0).WithMessage("WeightGMLossRate must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.VerticalDensity >= 0).WithMessage("VerticalDensity must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.VerticalDensityLossRate >= 0).WithMessage("VerticalDensityLossRate must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.HorizontalDensity >= 0).WithMessage("HorizontalDensity must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.HorizontalDensityLossRate >= 0).WithMessage("HorizontalDensityLossRate must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.WrapShrinkage >= 0).WithMessage("WrapShrinkage must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.WeftShrinkage >= 0).WithMessage("WeftShrinkage must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.Gauge >= 0).WithMessage("Gauge must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.Feeder >= 0).WithMessage("Feeder must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.UsedFeeder >= 0).WithMessage("UsedFeeder must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.Needle >= 0).WithMessage("Needle must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.RappoLength >= 0).WithMessage("RappoLength must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.MachineDiameter >= 0).WithMessage("MachineDiameter must greater than or equal 0.");
            RuleFor(p => p).Must(p => p.WeightKg >= 0).WithMessage("WeightKg must greater than or equal 0.");
        }
    }
}
