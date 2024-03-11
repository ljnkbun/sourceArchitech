using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class CriticalPartRepository : GenericRepositoryAsync<CriticalPart>, ICriticalPartRepository
    {
        public CriticalPartRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
		public async Task<bool> IsNameUniqueAsync(string name, int? id = null)
		{
			return await _dbContext.Set<CriticalPart>().AllAsync(x => x.Name != name || (x.Id == id && x.Name == name));
		}
	}
}
