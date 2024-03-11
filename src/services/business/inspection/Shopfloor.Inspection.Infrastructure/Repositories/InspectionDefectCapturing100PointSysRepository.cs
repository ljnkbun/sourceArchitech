using AutoMapper;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class InspectionDefectCapturing100PointSysRepository : GenericRepositoryAsync<InspectionDefectCapturing100PointSys>, IInspectionDefectCapturing100PointSysRepository
    {
        public InspectionDefectCapturing100PointSysRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
