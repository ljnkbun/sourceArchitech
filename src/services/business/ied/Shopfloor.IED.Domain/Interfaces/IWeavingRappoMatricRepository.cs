using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IWeavingRappoMatricRepository : IGenericRepositoryAsync<WeavingRappoMatric>
    {
        Task<List<WeavingRappoMatric>> GetListAsync(int weavingRappoId);
    }
}
