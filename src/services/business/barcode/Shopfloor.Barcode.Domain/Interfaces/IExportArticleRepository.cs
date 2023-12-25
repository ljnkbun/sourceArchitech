using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IExportArticleRepository : IMasterRepositoryAsync<ExportArticle>
    {
        Task<ExportArticle> GetExportArticleByIdAsync(int id);
        Task UpdateExportArticleAsync(ExportArticle entity, IEnumerable<ExportDetail> deleteDetails);
    }
}
