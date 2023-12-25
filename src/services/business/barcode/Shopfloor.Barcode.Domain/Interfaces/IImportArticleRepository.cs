using Shopfloor.Core.Repositories;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Constants;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IImportArticleRepository : IGenericRepositoryAsync<ImportArticle>
    {
        Task<List<ImportArticle>> GetImportArticleByIdsAsync(int[] id);
        Task<ImportArticle> GetImportArticleByIdAsync(int id);
        Task UpdateImportArticleAsync(ImportArticle entity, IEnumerable<ImportDetail> addedDetails, IEnumerable<ImportDetail> modifiedDetails, IEnumerable<ImportDetail> deletedDetails);
        Task DeleteImportArticleAsync(ImportArticle entity, IEnumerable<ArticleBarcode> deleteArticleBarcodes);
        Task<ImportType?> GetImportTypeByIdImportId(int id);
        Task AddImportArticleHasBarCodeAsync(ImportArticle entity, IEnumerable<ArticleBarcode> modifiedArticleBarcodes);
    }
}
