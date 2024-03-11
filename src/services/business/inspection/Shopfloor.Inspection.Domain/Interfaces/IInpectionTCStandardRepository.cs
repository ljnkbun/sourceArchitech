using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Domain.Interfaces
{
    public interface IInpectionTCStandardRepository : IGenericRepositoryAsync<InpectionTCStandard>
    {
        Task<InpectionTCStandard> GetInpectionTCStandardWithDetaiḷ(int id);
        Task UpdateInspectionTCStandardAsync(InpectionTCStandard inspectionTCStandard, IEnumerable<InspectionDefectCapturingTCStandard> inspectionDefectCapturingTCStandards);
    }
}
