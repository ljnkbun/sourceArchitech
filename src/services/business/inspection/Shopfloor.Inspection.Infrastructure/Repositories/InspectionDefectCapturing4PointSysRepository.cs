using AutoMapper;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class InspectionDefectCapturing4PointSysRepository : GenericRepositoryAsync<InspectionDefectCapturing4PointSys>, IInspectionDefectCapturing4PointSysRepository
    {
        public InspectionDefectCapturing4PointSysRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
