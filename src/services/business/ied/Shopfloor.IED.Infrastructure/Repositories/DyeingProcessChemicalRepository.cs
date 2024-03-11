using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class DyeingProcessChemicalRepository : GenericRepositoryAsync<DyeingProcessChemical>, IDyeingProcessChemicalRepository
    {
        public DyeingProcessChemicalRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DyeingProcessChemical>().AnyAsync(x => x.Id == id);
        }
    }
}