using AutoMapper;
using Shopfloor.Ambassador.Domain.Entities;
using Shopfloor.Ambassador.Domain.Interfaces;
using Shopfloor.Ambassador.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Ambassador.Infrastructure.Repositories
{
    public class TestEntityRepository : GenericRepositoryAsync<TestEntity>, ITestEntityRepository
    {
        public TestEntityRepository(AmbassadorContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
