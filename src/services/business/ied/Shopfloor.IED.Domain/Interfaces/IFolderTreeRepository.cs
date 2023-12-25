using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IFolderTreeRepository : IGenericRepositoryAsync<FolderTree>
    {
        Task<FolderTree> GetFolderTreeByIdAsync(int id);
        Task<bool> IsNotInUseAsync(int id);
    }
}
