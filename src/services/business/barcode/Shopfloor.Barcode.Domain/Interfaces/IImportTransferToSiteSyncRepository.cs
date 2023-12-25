using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IImportTransferToSiteSyncRepository : IGenericRepositoryAsync<ImportTransferToSiteSync>
    {
        Task<ImportTransferToSiteSync> GetByGDNNoAsync(string gdnNo);
    }
}
