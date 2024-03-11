using AutoMapper;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class QCDefectTypeRepository : MasterRepositoryAsync<QCDefectType>, IQCDefectTypeRepository
    {
        public QCDefectTypeRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
