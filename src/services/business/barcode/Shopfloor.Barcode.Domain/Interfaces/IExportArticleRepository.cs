using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IExportArticleRepository : IMasterRepositoryAsync<ExportArticle>
    {
        Task<ICollection<ExportArticle>> GetByIdsAsync(int[] ids);
        Task<List<ExportArticle>> GetExportArticleByExportIds(int[] ids);
        Task<ExportArticle> GetExportArticleByIdAsync(int id);
        Task UpdateExportArticleAsync(ExportArticle entity, IEnumerable<ExportDetail> addedDetails, IEnumerable<ExportDetail> modifiedDetails, IEnumerable<ExportDetail> deletedDetails);
    }
}
