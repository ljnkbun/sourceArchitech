using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Domain.Interfaces
{
    public interface IQCDefinitionRepository : IMasterRepositoryAsync<QCDefinition>
    {
        Task<QCDefinition> GetQCDefinitionByCode(string code);
        Task<QCType> GetQCTypeByQCDefinitionCode(string code);
        Task<QCDefinition> GetQCDefinitionWithIncludeById(int id);
        Task UpdateQCDefinitionsync(QCDefinition qcDefinition, ICollection<QCDefinitionDefect> deletedQCDefinitionDefects, ICollection<QCDefinitionDefect> insertedQCDefinitionDefect);
    }
}
