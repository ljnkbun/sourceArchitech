using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IMaterialTypeMapProductGroupRepository : IGenericRepositoryAsync<MaterialTypeMapProductGroup>
    {
        Task<bool> IsDuplicateAsync(int? materialTypeId, int? productGroupId, int? id = null);
    }
}
