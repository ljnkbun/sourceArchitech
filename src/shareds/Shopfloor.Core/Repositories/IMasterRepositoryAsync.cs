using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Core.Repositories
{
    public interface IMasterRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : BaseMasterEntity
    {
        Task<bool> IsUniqueAsync(string code, int? id = null);
    }
}
