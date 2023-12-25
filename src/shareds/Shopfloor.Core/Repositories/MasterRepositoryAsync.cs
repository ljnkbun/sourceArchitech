using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Core.Repositories
{
    public class MasterRepositoryAsync<T> : GenericRepositoryAsync<T>, IMasterRepositoryAsync<T> where T : BaseMasterEntity
    {

        public MasterRepositoryAsync(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public async Task<bool> IsUniqueAsync(string code, int? id = null)
        {
            return await _dbContext.Set<T>().AllAsync(x => x.Code != code || (x.Id == id && x.Code == code));
        }
    }
}
