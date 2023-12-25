using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IImportRepository : IMasterRepositoryAsync<Import>
    {
        Task<Import> GetImportByIdAsync(int id);
        Task UpdateImportAsync(Import entity, IEnumerable<ImportArticle> modifiedArticles, IEnumerable<ImportArticle> deletedArticles, IEnumerable<ImportDetail> addedDetails, IEnumerable<ImportDetail> modifiedDetails, IEnumerable<ImportDetail> deletedDetails );
        Task DeleteImportAsync(Import entity, IEnumerable<ArticleBarcode> deleteArticleBarcodes);
        Task AddImportHasBarCodeAsync(Import entity, IEnumerable<ArticleBarcode> modifiedArticleBarcodes);
        Task <Import> ViewImportByIdAsync(int id);
    }
}
