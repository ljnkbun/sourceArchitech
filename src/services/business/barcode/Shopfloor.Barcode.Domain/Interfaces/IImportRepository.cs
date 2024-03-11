using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IImportRepository : IMasterRepositoryAsync<Import>
    {
        Task<Import> GetImportByIdAsync(int id);
        Task UpdateImportAsync(Import entity, IEnumerable<ImportArticle> addedArticles, IEnumerable<ImportArticle> modifiedArticles, IEnumerable<ImportArticle> deletedArticles, IEnumerable<ImportDetail> addedDetails, IEnumerable<ImportDetail> modifiedDetails, IEnumerable<ImportDetail> deletedDetails);
        Task DeleteImportAsync(Import entity, IEnumerable<ArticleBarcode> deleteArticleBarcodes);
        Task AddImportHasBarCodeAsync(Import entity, IEnumerable<ArticleBarcode> modifiedArticleBarcodes);
        Task<Import> ViewImportByIdAsync(int id);
        Task<PagedResponse<IReadOnlyList<TModel>>> GetModelPagedCustomReponseAsync<TParam, TModel>(TParam parameter, ImportStatus[] importStatuses, ImportType[] importTypes, string articleCode, string articleName, string pONo, WfxStatus[] wfxStatuses) where TParam : RequestParameter where TModel : class;
        Task<ICollection<Import>> GetByIdsAsync(int[] ids);
    }
}
