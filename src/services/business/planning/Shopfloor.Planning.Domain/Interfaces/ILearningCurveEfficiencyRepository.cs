using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface ILearningCurveEfficiencyRepository : IMasterRepositoryAsync<LearningCurveEfficiency>
    {
        Task<LearningCurveEfficiency> GetLearningCurveEfficiencyByIdAsync(int? id = null);
        Task<List<LearningCurveEfficiency>> GetByIdsAsync(List<int> ids);
    }
}
