using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IArticleBarcodeRepository : IGenericRepositoryAsync<ArticleBarcode>
    {
        Task<bool> IsUniqueBarcodeAsync(string barcode, int? id = null);
        Task<PagedResponse<IReadOnlyList<TModel>>> GetModelPagedCustomReponseAsync<TParam, TModel>(TParam parameter, string barcodes, string articleCodes) where TParam : RequestParameter where TModel : class;
        Task<ArticleBarcode> GetByBarcodeAsync(string barcode);
        Task UpdateArticleBarcodeLocationAsync(ArticleBarcode articleBarcode, BarcodeLocation barcodeLocation);
        Task<Dictionary<string, ArticleBarcode>> GetByBarCodesAsync(string[] barCodes);
        Task<Dictionary<int, ArticleBarcode>> GetByBarIdsAsync(int[] ids);
        Task<ICollection<ArticleBarcode>> GetByIdsAsync(ICollection<int> ids);
        Task<int[]> SplitImportBarcodeDetail(ArticleBarcode entity, List<ArticleBarcode> splitBarcodes);
        Task<ArticleBarcode> MergeImportBarcodeDetail(ICollection<ArticleBarcode> mergeBarcodes);
        Task<ICollection<ArticleBarcode>> GetAllByBarcodesAsync(string[] barcodes);
        Task<bool> UpdateArticleBarcodesLocationAsync(ICollection<ArticleBarcode> entities, ICollection<BarcodeLocation> newBarcodeLocations);
    }
}
