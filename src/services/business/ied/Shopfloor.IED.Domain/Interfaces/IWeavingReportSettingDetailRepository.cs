using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IWeavingReportSettingDetailRepository : IGenericRepositoryAsync<WeavingReportSettingDetail>
{
    Task<bool> IsExistAsync(int id);
}