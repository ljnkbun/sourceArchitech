using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IImportArticleRepository : IGenericRepositoryAsync<ImportArticle>
    {
        Task<List<ImportArticle>> GetImportArticleByIdsAsync(int[] ids);
        Task<ImportArticle> GetImportArticleByIdAsync(int id);
        Task UpdateImportArticleAsync(ImportArticle entity, IEnumerable<ImportDetail> addedDetails, IEnumerable<ImportDetail> modifiedDetails, IEnumerable<ImportDetail> deletedDetails);
        Task DeleteImportArticleAsync(ImportArticle entity, IEnumerable<ArticleBarcode> deleteArticleBarcodes);
        Task<List<ImportArticle>> GetImportArticleByImportIds(int[] ids);
        Task AddImportArticleHasBarCodeAsync(ImportArticle entity, IEnumerable<ArticleBarcode> modifiedArticleBarcodes);
        Task<ICollection<ImportArticle>> GetByIdsAsync(int[] ids);
        Task<Response<IReadOnlyList<TModel>>> GetImportSyncAsync<TParam, TModel>(List<TParam> parameter)
           where TModel : class
           where TParam : RequestParameter;
    }
}
