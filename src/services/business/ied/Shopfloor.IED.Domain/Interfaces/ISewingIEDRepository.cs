using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingIEDRepository : IGenericRepositoryAsync<SewingIED>
    {
        Task<SewingIED> GetSewingIEDByIdAsync(int id);
    }
}
