using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IFormulaFieldRepository : IGenericRepositoryAsync<FormulaField>
    {
        Task<bool> IsUniqueAsync(string fieldName, int? id = null);
    }
}
