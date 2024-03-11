using AutoMapper;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class OneHundredPointSystemDetailRepository : GenericRepositoryAsync<OneHundredPointSystemDetail>, IOneHundredPointSystemDetailRepository
    {
        public OneHundredPointSystemDetailRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
