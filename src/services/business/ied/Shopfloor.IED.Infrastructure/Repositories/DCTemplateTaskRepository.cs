using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class DCTemplateTaskRepository : GenericRepositoryAsync<DCTemplateTask>, IDCTemplateTaskRepository
    {
        public DCTemplateTaskRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DCTemplateTask>().AnyAsync(x => x.Id == id);
        }

        public async Task<DCTemplateTask> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DCTemplateTask>()
            .Include(x => x.DcTemplateDetails)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}