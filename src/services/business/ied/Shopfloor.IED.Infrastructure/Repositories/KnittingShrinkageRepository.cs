using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class KnittingShrinkageRepository : GenericRepositoryAsync<KnittingShrinkage>, IKnittingShrinkageRepository
    {
        public KnittingShrinkageRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<bool> IsUniqueAsync(string name, int? id = null)
        {
            return await _dbContext.Set<KnittingShrinkage>().AllAsync(x => x.Name != name || (x.Id == id && x.Name == name));
        }
    }
}
