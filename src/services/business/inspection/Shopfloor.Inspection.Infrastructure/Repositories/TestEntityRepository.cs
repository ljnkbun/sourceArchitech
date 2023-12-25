using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class TestEntityRepository : GenericRepositoryAsync<TestEntity>, ITestEntityRepository
    {
        public TestEntityRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
