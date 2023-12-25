using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IArticleBarcodeRepository : IGenericRepositoryAsync<ArticleBarcode>
    {
        Task<bool> IsUniqueBarcodeAsync(string barcode, int? id = null);
        Task<ArticleBarcode> GetByBarcodeAsync(string barcode);
        Task UpdateArticleBarcodeLocationAsync(ArticleBarcode articleBarcode, BarcodeLocation location);
        Task<Dictionary<string, ArticleBarcode>> GetByBarCodesAsync(string[] barCodes);
        Task<Dictionary<int, ArticleBarcode>> GetByBarIdsAsync(int[] ids);
        Task<ICollection<ArticleBarcode>> GetByIdsAsync(ICollection<int> ids);
        Task SplitImportBarcodeDetail(ArticleBarcode entity, List<ArticleBarcode> importdetails);
        Task MergeImportBarcodeDetail(ICollection<ArticleBarcode> entities);
    }
}
