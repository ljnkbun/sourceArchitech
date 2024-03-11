using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    internal class DyeingTBRChemicalRepository : GenericRepositoryAsync<DyeingTBRChemical>, IDyeingTBRChemicalRepository
    {
        public DyeingTBRChemicalRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DyeingTBRChemical>().AnyAsync(x => x.Id == id);
        }

        public async Task<DyeingTBRChemical> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DyeingTBRChemical>()
            .Include(x => x.DyeingTBRChemicalValues)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> UpdateDyeingTBRChemicalValueAsync(DyeingTBRChemical dataDyeingTBRTaskUpdate, BaseUpdateEntity<DyeingTBRChemicalValue> dataDyeingTBRChemicalValue)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<DyeingTBRChemicalValue>().RemoveRange(dataDyeingTBRChemicalValue.LstDataDelete);

                    _dbContext.Set<DyeingTBRChemicalValue>().AddRange(dataDyeingTBRChemicalValue.LstDataAdd);

                    _dbContext.Update(dataDyeingTBRTaskUpdate);
                    _dbContext.Set<DyeingTBRChemicalValue>().UpdateRange(dataDyeingTBRChemicalValue.LstDataUpdate);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    result = false;
                    await transaction.RollbackAsync();
                }
            }
            return result;
        }
    }
}