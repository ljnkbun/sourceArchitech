using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Domain.Interfaces
{
    public interface IInpection4PointSysRepository : IGenericRepositoryAsync<Inpection4PointSys>
    {
        Task<Inpection4PointSys> GetInpection4PointSysWithDetaiḷ(int id);
        Task UpdateInspection4PointSysAsync(Inpection4PointSys inspection4PointSys, IEnumerable<InspectionDefectCapturing4PointSys> inspectionDefectCapturing4PointSyss,
             IEnumerable<InspectionDefectError4PointSys> inspectionDefectError4PointSys);
    }

}
