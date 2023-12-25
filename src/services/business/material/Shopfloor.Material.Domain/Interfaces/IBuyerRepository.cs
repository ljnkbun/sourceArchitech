using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Domain.Interfaces;

public interface IBuyerRepository : IMasterRepositoryAsync<Buyer>
{
    Task<Buyer> GetBuyerByIdAsync(int id);
    Task<List<Buyer>> GetBuyerByIdsAsync(int[] ids);
    Task<Buyer> GetBuyerByCodeAsync(string buyerCode);
    Task<PagedResponse<IReadOnlyList<TModel>>> GetListAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate) where TParam : RequestParameter where TModel : class;
    Task<bool> UpdateBuyerAsync(Buyer buyer, List<BuyerProductCategory> insertCategoryMappings, List<BuyerProductCategory> deleteCategoryMappings);
    Task<Buyer> AddBuyerAsync(Buyer entity);
    Task<bool> AddBuyerRangeAsync(List<Buyer> entities);
}
