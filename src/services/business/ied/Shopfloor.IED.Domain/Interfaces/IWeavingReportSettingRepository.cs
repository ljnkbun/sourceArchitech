using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IWeavingReportSettingRepository : IGenericRepositoryAsync<WeavingReportSetting>
{
    Task<bool> IsExistAsync(int id);

    Task<bool> UpdateWeavingReportSettingValueAsync(WeavingReportSetting dataWeavingReportSettingUpdate,
        BaseUpdateEntity<WeavingReportSettingDetail> dataWeavingReportSettingDetails);

    Task<WeavingReportSetting> GetWithIncludeByIdAsync(int id);

    Task<PagedResponse<IReadOnlyList<TModel>>>
        GetWeavingReportSettingPagedResponseAsync<TParam, TModel>(TParam parameter)
        where TParam : RequestParameter where TModel : class;

    Task<bool> IsExistByWeavingIEDAsync(int weavingIEDId);
}