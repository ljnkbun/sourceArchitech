using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class DyeingTBRCValueRepository : GenericRepositoryAsync<DyeingTBRCValue>, IDyeingTBRCValueRepository
    {
        public DyeingTBRCValueRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DyeingTBRCValue>().AnyAsync(x => x.Id == id);
        }

        public async Task<DyeingTBRCValue> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DyeingTBRCValue>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}