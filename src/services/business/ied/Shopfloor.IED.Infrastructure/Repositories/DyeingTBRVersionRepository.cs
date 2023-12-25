using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class DyeingTBRVersionRepository : GenericRepositoryAsync<DyeingTBRVersion>, IDyeingTBRVersionRepository
    {
        public DyeingTBRVersionRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DyeingTBRVersion>().AnyAsync(x => x.Id == id);
        }

        public async Task<DyeingTBRVersion> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DyeingTBRVersion>()
            .Include(x => x.DyeingTBRCValues)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}