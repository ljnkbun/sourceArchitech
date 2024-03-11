using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IExportRepository : IMasterRepositoryAsync<Export>
    {
        Task<ICollection<Export>> GetByIdsAsync(int[] ints);
        Task<Export> GetExportByIdAsync(int id);
        Task<Core.Models.Responses.PagedResponse<IReadOnlyList<TModel>>> GetModelPagedCustomReponseAsync<TParam, TModel>(TParam parameter, ExportStatus[] exportStatuses, ExportTypes[] exportTypes, WfxStatus[] wfxStatuses)
            where TParam : RequestParameter
            where TModel : class;
        Task UpdateExportAsync(Export entity, IEnumerable<ExportArticle> modifiedArticles, IEnumerable<ExportArticle> deletedArticles, IEnumerable<ExportDetail> addedDetails, IEnumerable<ExportDetail> modifiedDetails, IEnumerable<ExportDetail> deletedDetails);
    }
}
