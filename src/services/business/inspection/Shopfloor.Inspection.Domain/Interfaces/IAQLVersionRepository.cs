using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.Repositories;
using NPOI.SS.Formula.Functions;

namespace Shopfloor.Inspection.Domain.Interfaces
{
    public interface IAQLVersionRepository : IMasterRepositoryAsync<AQLVersion>
    {
        Task<AQLVersion> GetAQLVersionByIdAsync(int id);
        Task UpdateAQLVersionAsync(AQLVersion aQLVersion, ICollection<AQL> deletedAQLVersions, ICollection<AQL> insertedAQLVersions);
    }
}
