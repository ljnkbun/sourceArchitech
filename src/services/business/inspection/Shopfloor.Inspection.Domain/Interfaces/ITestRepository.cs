using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Inspection.Domain.Interfaces
{
    public interface ITestRepository : IMasterRepositoryAsync<Test>
    {
    }
}
