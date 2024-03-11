using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class LearningCurveEfficiencyRepository : MasterRepositoryAsync<LearningCurveEfficiency>, ILearningCurveEfficiencyRepository
    {
        private readonly DbSet<LearningCurveEfficiency> _learningCurveEfficiencies;
        public LearningCurveEfficiencyRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _learningCurveEfficiencies = _dbContext.Set<LearningCurveEfficiency>();
        }
        public async Task<LearningCurveEfficiency> GetLearningCurveEfficiencyByIdAsync(int? id)
        {
            return await _learningCurveEfficiencies
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async override Task<LearningCurveEfficiency> GetByIdAsync(int id)
        {
            return await _learningCurveEfficiencies.Include(x => x.LearningCurveDetailEfficiencies).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LearningCurveEfficiency>> GetByIdsAsync(List<int> ids)
        {
            return await _learningCurveEfficiencies.Where(x => ids.Contains(x.Id)).Include(x => x.LearningCurveDetailEfficiencies).ToListAsync();
        }
    }
}
