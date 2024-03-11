using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IRequestTypeRepository : INameRepositoryAsync<RequestType>
    {
        Task<bool> IsExistAsync(int id);
    }
}
