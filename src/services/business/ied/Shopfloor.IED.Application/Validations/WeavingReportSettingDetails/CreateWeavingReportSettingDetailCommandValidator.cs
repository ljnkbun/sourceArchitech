using System.Text.RegularExpressions;
using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingReportSettingDetails;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.WeavingReportSettingDetails
{
    public class CreateWeavingReportSettingDetailCommandValidator : AbstractValidator<CreateWeavingReportSettingDetailCommand>
    {
        private readonly IWeavingReportSettingRepository _weavingReportSetting;

        public CreateWeavingReportSettingDetailCommandValidator(IWeavingReportSettingRepository weavingReportSetting)
        {
            _weavingReportSetting = weavingReportSetting;

            RuleFor(p => p.Split)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed 100 characters.")
                .NotEmpty()
                .WithMessage("{PropertyName} must required."); ;

            RuleFor(p => p.WeavingReportSettingId)
                .MustAsync(IsExistWeavingReportSettingAsync)
                .WithMessage("{PropertyName} not found.");

            RuleFor(p => p.Split)
                .Must(IsSplitRegexAsync)
                .WithMessage("{PropertyName} wrong format.");

            RuleFor(p => p)
                .Must(IsCheckReportSettingDetail)
                .WithMessage("Split wrong format.");
        }

        private async Task<bool> IsExistWeavingReportSettingAsync(int weavingReportSettingId, CancellationToken token)
        {
            return await _weavingReportSetting.IsExistAsync(weavingReportSettingId);
        }

        private bool IsCheckReportSettingDetail(CreateWeavingReportSettingDetailCommand data)
        {
            var dataRs = data.Split.Replace(" ", "").Split(",").Select(int.Parse).ToList();
            var expected = dataRs[0];
            return dataRs.Skip(1).All(value =>
            {
                if (value != expected + 1)
                {
                    return false;
                }
                expected = value;
                return true;
            });
        }

        private bool IsSplitRegexAsync(string split) => Regex.IsMatch(split, "^[0-9, ]+$");
    }
}