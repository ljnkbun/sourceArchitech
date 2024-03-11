using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IWeavingRappoMarkRepository : IGenericRepositoryAsync<WeavingRappoMark>
    {
        Task<List<WeavingRappoMark>> GetListAsync(int weavingRappoId);
    }
}
