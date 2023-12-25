using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    }
}