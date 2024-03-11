using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Domain.Interfaces
{
    public interface IInpection100PointSysRepository : IGenericRepositoryAsync<Inpection100PointSys>
    {
        Task<Inpection100PointSys> GetInpection100PointSysWithDetaiḷ(int id);
        Task UpdateInspection100PointSysAsync(Inpection100PointSys inspection100PointSys, IEnumerable<InspectionDefectCapturing100PointSys> inspectionDefectCapturing100PointSyss,
             IEnumerable<InspectionDefectError100PointSys> inspectionDefectError100PointSys);
    }
}
