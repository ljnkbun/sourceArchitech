using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Core.Repositories
{
    public class NameRepositoryAsync<T> : GenericRepositoryAsync<T> where T : BaseNameEntity
    {
        public NameRepositoryAsync(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? id = null)
        {
            return await _dbContext.Set<T>().AllAsync(x => x.Name != name || (x.Id == id && x.Name == name));
        }
    }
}
