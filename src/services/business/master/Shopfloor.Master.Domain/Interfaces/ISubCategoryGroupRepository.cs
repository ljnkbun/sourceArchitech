using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface ISubCategoryGroupRepository : IMasterRepositoryAsync<SubCategoryGroup>
    {
        Task<bool> IsExistAsync(int id);
    }
}
