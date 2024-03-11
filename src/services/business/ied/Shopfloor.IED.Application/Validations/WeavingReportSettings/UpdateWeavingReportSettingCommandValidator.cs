using System.Text.RegularExpressions;
using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingReportSettings;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.WeavingReportSettings
{
    public class UpdateWeavingReportSettingCommandValidator : AbstractValidator<UpdateWeavingReportSettingCommand>
    {
        private readonly IWeavingIEDRepository _weavingIed;

        private readonly IWeavingReportSettingRepository _weavingReportSetting;

        public UpdateWeavingReportSettingCommandValidator(IWeavingReportSettingRepository weavingReportSetting, IWeavingIEDRepository weavingIed)
        {
            _weavingReportSetting = weavingReportSetting;
            _weavingIed = weavingIed;

            RuleFor(p => p.SettingType)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.WeavingIEDId)
                .MustAsync(IsExistWeavingIEDAsync)
                .WithMessage("{PropertyName} not found.");

            RuleFor(p => p).Custom(IsCheckReportSettingDetail);

            RuleForEach(p => p.WeavingReportSettingDetails).ChildRules(childWeavingReportSettingDetails =>
            {
                childWeavingReportSettingDetails.RuleFor(p => p.Split)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                childWeavingReportSettingDetails.RuleFor(p => p.Split)
                    .NotEmpty().WithMessage("{PropertyName} must required.");

                childWeavingReportSettingDetails.RuleFor(p => p.Split)
                    .Must(IsSplitRegexAsync)
                    .WithMessage("{PropertyName} wrong format.");
            });
        }

        private async Task<bool> IsExistWeavingIEDAsync(int weavingIEDId, CancellationToken token)
        {
            return await _weavingIed.IsExistAsync(weavingIEDId);
        }

        private void IsCheckReportSettingDetail(UpdateWeavingReportSettingCommand data,
            ValidationContext<UpdateWeavingReportSettingCommand> context)
        {
            if (data.WeavingReportSettingDetails.Any(x => string.IsNullOrEmpty(x.Split)))
            {
                context.AddFailure(string.Join(Environment.NewLine, $"Split wrong format"));
            }
            var splitValues = data.WeavingReportSettingDetails
                .Select(x => new
                {
                    Values = x.Split.Replace(" ", "").Split(",").Select(int.Parse).ToList(),
                    x.GroupIndex
                })
                .ToList();
            var expected = 0;
            _ = splitValues.All(list =>
            {
                return list.Values.All(value =>
                {
                    if (value != expected + 1)
                    {
                        context.AddFailure(string.Join(Environment.NewLine, $"Group {list.GroupIndex} wrong format"));
                        return false;
                    }
                    expected = value;
                    return true;
                });
            }) && splitValues.Zip(splitValues.Skip(1), (list1, list2) =>
            {
                if (list1.Values.Last() + 1 == list2.Values.First())
                {
                    return true;
                }
                context.AddFailure(string.Join(Environment.NewLine, $"Group {list1.GroupIndex} and group {list2.GroupIndex} wrong format"));
                return false;
            }).All(result => result);
        }

        private bool IsSplitRegexAsync(string split) => Regex.IsMatch(split, "^[0-9, ]+$");
    }
}