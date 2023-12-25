using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingOperationWFXRepository : GenericRepositoryAsync<SewingOperationWFX>, ISewingOperationWFXRepository
    {
        public SewingOperationWFXRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<SewingOperationWFX> GetSewingOperationWFXAsync(int id, int version)
        {
            return await _dbContext.Set<SewingOperationWFX>()
                                    .Where(s => s.Id == id)
                                    .Include(s => s.SewingOperationWFXVersions.Where(v => v.Version == version))
                                        .ThenInclude(v => v.SewingSubOperationWFXs)
                                    .FirstOrDefaultAsync();
        }

        public async Task AddSewingOperationWFXAsync(SewingOperationWFX entity)
        {
            int firstVersion = 1;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    entity.CurrentVersionId = firstVersion;
                    await AddAsync(entity);
                    await AddSewingOperationWFXVersion(entity.Id, firstVersion);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex.Message, ex);
                    throw new ApiException($"Creating failed.");
                }
            }
        }
        public async Task AddVersionAsync(int sewingOperationWFXId)
        {
            int newVersion = await GetLastestVersion(sewingOperationWFXId) + 1;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var operation = await GetByIdAsync(sewingOperationWFXId);
                    operation.CurrentVersionId = newVersion;
                    await UpdateAsync(operation);
                    await AddSewingOperationWFXVersion(sewingOperationWFXId, newVersion);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex.Message, ex);
                    throw new ApiException($"Updating failed.");
                }
            }
        }
        
        private async Task<int> GetLastestVersion(int sewingOperationWFXId)
        {
            var lastestVersion = await _dbContext.Set<SewingOperationWFXVersion>()
                                            .Where(v => v.SewingOperationWFXId == sewingOperationWFXId)
                                            .OrderByDescending(v => v.Version)
                                            .FirstOrDefaultAsync();
            if (lastestVersion == null)
                return 0;
            return lastestVersion.Version;
        }

        private async Task AddSewingOperationWFXVersion(int id, int version)
        {
            var entity = new SewingOperationWFXVersion()
            {
                SewingOperationWFXId = id,
                Version = version
            };
            await _dbContext.Set<SewingOperationWFXVersion>().AddAsync(entity);
        }

        public async Task<List<SewingOperationWFXVersion>> GetVersionsAsync(int sewingOperationWFXId)
        {
            return await _dbContext.Set<SewingOperationWFXVersion>()
                                        .Where(v => v.SewingOperationWFXId == sewingOperationWFXId)
                                        .OrderBy(v => v.Version)
                                        .ToListAsync();
        }
    }
}
