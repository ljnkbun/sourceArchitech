using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Domain.Interfaces
{
    public interface IPriceListDetailRepository : IGenericRepositoryAsync<PriceListDetail>
    {
        Task<PagedResponse<IReadOnlyList<TModel>>> GetPriceListDetailPagedReponseAsync<TParam, TModel>(TParam parameter,
            DateTime? fromDate, DateTime? toDate)
            where TModel : class
            where TParam : RequestParameter;

        Task<bool> UpdatePriceListDetailAsync(PriceListDetail dataUpdate
            , BaseListCreateDeleteEntity<PriceListDetailColor> dataPriceListDetailColor
            , BaseListCreateDeleteEntity<PriceListDetailSize> dataPriceListDetailSize);

        Task<List<PriceListDetail>> GetPriceListDetailByIdsAsync(int[] ids);

        Task<PriceListDetail> GetWithIncludeByIdAsync(int id);

        Task<List<PriceListDetail>> GetPriceListDetailByParentIdAsync(int parentId);
    }
}