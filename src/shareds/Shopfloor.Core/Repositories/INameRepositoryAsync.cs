using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Core.Repositories
{
    public interface INameRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : BaseNameEntity
    {
        Task<bool> IsNameUniqueAsync(string name, int? id = null);
    }
}
