using AutoMapper;
using Serilog;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class WeavingSpecificationRepository : GenericRepositoryAsync<WeavingYarn>, IWeavingSpecificationRepository
    {
        public WeavingSpecificationRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task AddWeavingSpecificationAsync(BaseUpdateEntity<WeavingYarn> weavingYarns, BaseUpdateEntity<WeavingDetailStructure> weavingDetailStructures, WeavingRusticFabricSpec weavingRusticFabricSpec)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<WeavingYarn>().RemoveRange(weavingYarns.LstDataDelete);
                    _dbContext.Set<WeavingDetailStructure>().RemoveRange(weavingDetailStructures.LstDataDelete);

                    _dbContext.Set<WeavingYarn>().UpdateRange(weavingYarns.LstDataUpdate);
                    _dbContext.Set<WeavingDetailStructure>().UpdateRange(weavingDetailStructures.LstDataUpdate);

                    _dbContext.Set<WeavingYarn>().AddRange(weavingYarns.LstDataAdd);
                    _dbContext.Set<WeavingDetailStructure>().AddRange(weavingDetailStructures.LstDataAdd);

                    if (weavingRusticFabricSpec.Id == 0)
                    {
                        _dbContext.Set<WeavingRusticFabricSpec>().Add(weavingRusticFabricSpec);
                    }
                    else
                    {
                        _dbContext.Set<WeavingRusticFabricSpec>().Update(weavingRusticFabricSpec);
                    }
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex.Message, ex);
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }

        public async Task AddWeavingRappoSpecificationAsync(BaseUpdateEntity<WeavingYarn> weavingYarns, BaseUpdateEntity<WeavingDetailStructure> weavingDetailStructures, WeavingRusticFabricSpec weavingRusticFabricSpec, WeavingRappo weavingRappo, BaseUpdateEntity<WeavingRappoMark> weavingRappoMarks, BaseUpdateEntity<WeavingRappoMatric> weavingRappoMatrics)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<WeavingYarn>().RemoveRange(weavingYarns.LstDataDelete);
                    _dbContext.Set<WeavingDetailStructure>().RemoveRange(weavingDetailStructures.LstDataDelete);

                    _dbContext.Set<WeavingYarn>().UpdateRange(weavingYarns.LstDataUpdate);
                    _dbContext.Set<WeavingDetailStructure>().UpdateRange(weavingDetailStructures.LstDataUpdate);
                    _dbContext.Set<WeavingRusticFabricSpec>().Update(weavingRusticFabricSpec);

                    _dbContext.Set<WeavingYarn>().AddRange(weavingYarns.LstDataAdd);
                    _dbContext.Set<WeavingDetailStructure>().AddRange(weavingDetailStructures.LstDataAdd);

                    if (weavingRappo.Id == 0)
                    {
                        _dbContext.Set<WeavingRappo>().Add(weavingRappo);
                    }
                    else
                    {
                        _dbContext.Set<WeavingRappoMatric>().RemoveRange(weavingRappoMatrics.LstDataDelete);
                        _dbContext.Set<WeavingRappoMark>().RemoveRange(weavingRappoMarks.LstDataDelete);

                        _dbContext.Set<WeavingRappoMatric>().UpdateRange(weavingRappoMatrics.LstDataUpdate);
                        _dbContext.Set<WeavingRappoMark>().UpdateRange(weavingRappoMarks.LstDataUpdate);

                        _dbContext.Set<WeavingRappoMatric>().AddRange(weavingRappoMatrics.LstDataAdd);
                        _dbContext.Set<WeavingRappoMark>().AddRange(weavingRappoMarks.LstDataAdd);

                        _dbContext.Set<WeavingRappo>().Update(weavingRappo);
                    }
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex.Message, ex);
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }
    }
}