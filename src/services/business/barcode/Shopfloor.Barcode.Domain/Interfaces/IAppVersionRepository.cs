using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces;

public interface IAppVersionRepository : IGenericRepositoryAsync<AppVersion>
{
    Task<AppVersion> GetLastVersion();
}