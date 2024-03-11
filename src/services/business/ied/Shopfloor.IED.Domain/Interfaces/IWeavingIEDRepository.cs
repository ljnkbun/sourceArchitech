using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IWeavingIEDRepository : IGenericRepositoryAsync<WeavingIED>
    {
        Task<WeavingIED> GetWeavingIEDByIdAsync(int id);

        Task<bool> IsExistAsync(int id);
    }
}