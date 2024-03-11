using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IProductGroupUOMRepository : IGenericRepositoryAsync<ProductGroupUOM>
    {
        Task<bool> IsDuplicateAsync(int? productGroupId, int? uOMId, int? id = null);
    }
}