using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class MergeSplitPorDetailRepostiry : GenericRepositoryAsync<MergeSplitPorDetail>, IMergeSplitPorDetailRepostiry
    {
        private readonly DbSet<MergeSplitPorDetail> _mergeSplitPorDetail;
        public MergeSplitPorDetailRepostiry(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _mergeSplitPorDetail = dbContext.Set<MergeSplitPorDetail>();
        }

        public async Task<List<MergeSplitPorDetail>> GetByToPorDetailIds(ICollection<int> ids)
        {
            return await _mergeSplitPorDetail.Where(x => ids.Contains(x.ToPorDetailId)).ToListAsync();
        }
    }
}
