using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class MergeSplitPORRepository : GenericRepositoryAsync<MergeSplitPOR>, IMergeSplitPORRepository
    {
        private readonly DbSet<POR> _por;
        private readonly DbSet<PORDetail> _porDetail;
        private readonly DbSet<MergeSplitPOR> _mergeSplitPor;
        private readonly DbSet<MergeSplitPorDetail> _mergeSplitPorDetail;

        public MergeSplitPORRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _por = dbContext.Set<POR>();
            _porDetail = dbContext.Set<PORDetail>();
            _mergeSplitPor = dbContext.Set<MergeSplitPOR>();
            _mergeSplitPorDetail = dbContext.Set<MergeSplitPorDetail>();
        }

        public async Task DeleteMergeSplitPorAsync(ICollection<POR> porUpdates, ICollection<PORDetail> pORDetailUpdates, ICollection<MergeSplitPorDetail> mergeSplitPorDetails, POR por)
        {
            var trans = _dbContext.Database.BeginTransaction();
            try
            {
                _por.UpdateRange(porUpdates);
                _porDetail.UpdateRange(pORDetailUpdates);

                // Delete Merge POR Detail
                _mergeSplitPorDetail.RemoveRange(mergeSplitPorDetails);

                // Detele POR Detail
                _porDetail.RemoveRange(por.PORDetails.ToList());

                // Detele Merge POR
                _mergeSplitPor.RemoveRange(por.ToMergeSplitPORs.ToList());

                // Detele POR
                _por.Remove(por);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<List<MergeSplitPOR>> GetByToPorIds(ICollection<int> ids)
        {
            return await _mergeSplitPor.Where(x => ids.Equals(x.ToPORId)).ToListAsync();
        }
    }
}
