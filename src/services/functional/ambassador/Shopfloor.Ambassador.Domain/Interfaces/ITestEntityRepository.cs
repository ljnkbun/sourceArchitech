using Shopfloor.Ambassador.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Ambassador.Domain.Interfaces
{
    public interface ITestEntityRepository : IGenericRepositoryAsync<TestEntity>
    {
    }
}
