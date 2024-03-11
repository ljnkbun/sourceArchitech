using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface ICriticalPartRepository : IGenericRepositoryAsync<CriticalPart>
    {
		Task<bool> IsNameUniqueAsync(string name, int? id = null);
	}
}
