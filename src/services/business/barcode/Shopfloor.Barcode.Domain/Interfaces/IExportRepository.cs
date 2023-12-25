using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IExportRepository : IMasterRepositoryAsync<Export>
    {
        Task<Export> GetExportByIdAsync(int id);
        Task UpdateExportAsync(Export entity, IEnumerable<ExportArticle> deleteArticles, IEnumerable<ExportDetail> deleteDetails);
    }
}
