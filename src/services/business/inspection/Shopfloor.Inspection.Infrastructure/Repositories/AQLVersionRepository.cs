using AutoMapper;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class AQLVersionRepository : MasterRepositoryAsync<AQLVersion>, IAQLVersionRepository
    {
        private readonly DbSet<Inspection.Domain.Entities.AQLVersion> _aqlVersions;
        private readonly DbSet<Inspection.Domain.Entities.AQL> _aqls;
        public AQLVersionRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _aqlVersions = _dbContext.Set<AQLVersion>();
            _aqls = _dbContext.Set<AQL>();
        }
        public async Task<AQLVersion> GetAQLVersionByIdAsync(int id)
        {
            return await _aqlVersions.Include(x => x.AQLs).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateAQLVersionAsync(AQLVersion aQLVersion, ICollection<AQL> deletedAQLs, ICollection<AQL> insertedAQLs)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _aqls.RemoveRange(deletedAQLs);
                _aqls.AddRange(insertedAQLs);
                _aqlVersions.Update(aQLVersion);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }
    }
}
