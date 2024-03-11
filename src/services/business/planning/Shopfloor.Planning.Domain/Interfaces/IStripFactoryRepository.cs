using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface IStripFactoryRepository : IGenericRepositoryAsync<StripFactory>
    {
        Task<List<int>> GetPORIdsFromStripFactory(DateTime? fDate, DateTime? tDate, List<int> pfIds);
        Task<IReadOnlyList<TModel>> GetStripFactoryPorsAsync<TModel>(int planningGroupFactoryId, DateTime startDate, DateTime endDate) where TModel : class;
        Task<StripFactory> GetStripFactoryByIsAllocatedIsFalse(int id);
        Task<int?> InsertStripFactory(StripFactory entity);
        Task<bool> RejectStripFactoryAsync(List<StripFactory> entities);
        Task<IReadOnlyList<TModel>> GetModelByArticleCodeAsync<TModel>(string articleCode) where TModel : class; 
        Task<IReadOnlyList<TModel>> GetHistoryAsync<TModel>(string articleCode) where TModel : class;
        Task<bool> SaveMultipleStripFactory(List<StripFactory> stripFactories);
        Task<bool> IsExitPlanningGroupFactoryId(int planningGroupFactoryId);
        Task<List<StripFactory>> GetByIdsAsync(List<int> ids);
        Task<StripFactory> GetByIdIncludeAsync(int id);
        Task<List<StripFactory>> GetWithDetailByIdsAsync(List<int> ids);
        Task<IReadOnlyList<TModel>> GetDataForFactoryCapacities<TModel>(string porNo, DateTime startDate, DateTime endDate) where TModel : class;
        Task<List<StripFactory>> GetStripFactoryByPlanningFactoryIds(List<int> plgIds, DateTime fDate, DateTime tDate);

        Task DeleteStripFactory(StripFactory stripFactory);
        Task<PagedResponse<IReadOnlyList<TModel>>> GetStripFactoryModelPagedReponseAsync<TParam, TModel>(TParam parameter, 
            int? processId,
            string articleName,
            string articleCode,
            string buyer,
            string category,
            string subCategory,
            string productGroup,
            string jobOrderNo,
            string batchNo)
           where TModel : class
           where TParam : RequestParameter;
    }
}
