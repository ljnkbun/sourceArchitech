using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class FolderTreeRepository : GenericRepositoryAsync<FolderTree>, IFolderTreeRepository
    {
        public FolderTreeRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<FolderTree> GetFolderTreeByIdAsync(int id)
        {
            return await _dbContext.Set<FolderTree>()
                .Include(r => r.SubFolders)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> IsNotInUseAsync(int id)
        {
            var entity = await GetFolderTreeByIdAsync(id);
            if (entity.SubFolders.Count > 0 || entity.SewingMacroLibs.Count > 0 || entity.SewingOperationLibs.Count > 0 || entity.SewingFeatureLibs.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
