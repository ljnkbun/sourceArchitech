using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Inspection.Domain.Interfaces
{
    public interface IQCDefinitionDefectRepository : IGenericRepositoryAsync<QCDefinitionDefect>
    {
        Task<List<QCDefinitionDefect>> GetByQCDefinitionIdAsync(int qcDefinitionId);
    }
}
