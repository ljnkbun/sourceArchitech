using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IImportDetailRepository : IGenericRepositoryAsync<ImportDetail>
    {
        Task<List<ImportDetail>> GetByIdsAsync(int[] ids);
        Task DeleteImportTransferToSiteDetaiAsync(ImportDetail entity);
        Task<ImportDetail> GetImportDetailByIdAsync(int id);
        Task DeleteImportTransferToSiteDetaisAsync(List<ImportDetail> importTransferToSiteDetails);

        Task<List<TModel>> PrintImportDetail<TModel>(int[] ids);
        Task<ICollection<ArticleBarcode>> GenBarCode(string UOM, ICollection<ImportDetail> details);
        Task<ImportType?> GetImportTypeByIdImportArticleId(int id);
        Task AddImportDetailHasBarCodeAsync(ImportDetail entity, ArticleBarcode modifiedArticleBarcode);
    }
}
