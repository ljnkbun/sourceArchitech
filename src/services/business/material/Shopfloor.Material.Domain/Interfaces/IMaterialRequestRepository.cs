using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Domain.Interfaces
{
    public interface IMaterialRequestRepository : IGenericRepositoryAsync<MaterialRequest>
    {
        Task<PagedResponse<IReadOnlyList<TModel>>> GetMaterialPagedReponseAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate)
            where TModel : class
            where TParam : RequestParameter;

        Task<bool> UpdateMaterialRequestAsync(MaterialRequest datalUpdate,
            BaseUpdateEntity<MOQMSQRoudingOptionItem> dataMoqmsqRoudingOptionItem
            , BaseUpdateEntity<SupplierWisePurchaseOption> dataSupplierWisePurchaseOption
            , BaseUpdateEntity<FabricComposition> dataFabricComposition
            , BaseUpdateEntity<MaterialRequestDynamicColumn> dataMaterialRequestDynamicColumn);

        Task<List<MaterialRequest>> GetMaterialRequestByIdsAsync(int[] ids);

        Task<MaterialRequest> GetWithIncludeByIdAsync(int id);

        Task<MaterialRequest> AddMaterialRequestAsync(MaterialRequest entity);

        Task<bool> AddMaterialRequestRangeAsync(List<MaterialRequest> entities);

        Task<bool> IsExistAsync(int id);
    }
}