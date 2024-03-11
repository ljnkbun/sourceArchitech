using Shopfloor.Core.Repositories;

namespace Shopfloor.FileStorage.Domain.Interfaces
{
    public interface IFileRepository : IGenericRepositoryAsync<Entities.File>
    {
    }
}
