using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IExportDetailRepository : IMasterRepositoryAsync<ExportDetail>
    {
        Task<ICollection<ExportDetail>> GetByIdsAsync(int[] ids);
    }
}
