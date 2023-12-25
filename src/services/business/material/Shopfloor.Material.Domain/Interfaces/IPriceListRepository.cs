using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Domain.Interfaces
{
    public interface IPriceListRepository : IGenericRepositoryAsync<PriceList>
    {
        Task<PagedResponse<IReadOnlyList<TModel>>> GetPriceListPagedReponseAsync<TParam, TModel>(TParam parameter,
            DateTime? fromDate, DateTime? toDate)
            where TModel : class
            where TParam : RequestParameter;

        Task<bool> UpdatePriceListAsync(PriceList dataUpdate
            , BaseListCreateDeleteEntity<PriceListDetail> dataPriceListDetail);

        Task<bool> IsExistAsync(int id);

        Task<List<PriceList>> GetPriceListByIdsAsync(int[] ids);

        Task<PriceList> GetWithIncludeByIdAsync(int id);

        Task<PriceList> AddPriceListAsync(PriceList entity);

        Task<bool> AddPriceListRangeAsync(List<PriceList> entities);
    }
}