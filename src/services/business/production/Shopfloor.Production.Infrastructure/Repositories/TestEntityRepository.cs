using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;
using Shopfloor.Production.Infrastructure.Contexts;

namespace Shopfloor.Production.Infrastructure.Repositories
{
    public class TestEntityRepository : GenericRepositoryAsync<TestEntity>, ITestEntityRepository
    {
        public TestEntityRepository(ProductionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
