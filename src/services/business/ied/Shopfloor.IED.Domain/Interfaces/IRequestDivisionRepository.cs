using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IRequestDivisionRepository : IGenericRepositoryAsync<RequestDivision>
    {
        Task<List<RequestDivision>> GetListAsync(int requestId);
        Task<RequestDivision> GetRequestDivisionByIdAsync(int id);
        Task<bool> IsExistAsync(int id);
    }
}
