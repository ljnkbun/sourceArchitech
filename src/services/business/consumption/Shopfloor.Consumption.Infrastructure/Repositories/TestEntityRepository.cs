using AutoMapper;
using Shopfloor.Consumption.Domain.Entities;
using Shopfloor.Consumption.Domain.Interfaces;
using Shopfloor.Consumption.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Consumption.Infrastructure.Repositories
{
    public class TestEntityRepository : GenericRepositoryAsync<TestEntity>, ITestEntityRepository
    {
        public TestEntityRepository(ConsumptionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
