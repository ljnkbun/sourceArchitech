using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IRequestDivisionProcessRepository : IGenericRepositoryAsync<RequestDivisionProcess>
    {
        Task<RequestDivisionProcess> GetRequestDivisionProcessByIdAsync(int id);
    }
}
