using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class DyeingTBRChemicalValueRepository : GenericRepositoryAsync<DyeingTBRChemicalValue>, IDyeingTBRChemicalValueRepository
    {
        public DyeingTBRChemicalValueRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DyeingTBRChemicalValue>().AnyAsync(x => x.Id == id);
        }

        public async Task<bool> IsExistByRecipeIdAsync(int id, int version)
        {
            return await _dbContext.Set<DyeingTBRChemicalValue>().Include(x => x.DyeingTbrChemical).ThenInclude(x => x.DyeingTBRTask).AnyAsync(x => x.DyeingTbrChemical.DyeingTBRTask.DyeingTBRecipeId == id && x.VersionIndex == version);
        }

        public async Task<DyeingTBRChemicalValue> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DyeingTBRChemicalValue>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}