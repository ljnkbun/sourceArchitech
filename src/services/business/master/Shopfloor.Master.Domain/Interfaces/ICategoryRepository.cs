using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface ICategoryRepository : IMasterRepositoryAsync<Category>
    {
        Task<bool> IsExistAsync(int id);
    }
}
