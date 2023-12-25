using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Domain.Interfaces;

public interface ISupplierRepository : IGenericRepositoryAsync<Supplier>
{
    Task<PagedResponse<IReadOnlyList<TModel>>> GetSupplierPagedReponseAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate)
        where TModel : class
        where TParam : RequestParameter;

    Task<bool> UpdateSupplierAsync(Supplier datalUpdate,
        BaseListCreateDeleteEntity<SupplierProductCategory> dataSupplierProductCategory);

    Task<List<Supplier>> GetSupplierByIdsAsync(int[] ids);

    Task<Supplier> GetWithIncludeByIdAsync(int id);

    Task<Supplier> AddSupplierAsync(Supplier entity);

    Task<bool> AddSupplierRangeAsync(List<Supplier> entities);
}