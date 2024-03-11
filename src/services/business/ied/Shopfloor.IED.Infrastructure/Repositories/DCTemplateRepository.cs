using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class DCTemplateRepository : MasterRepositoryAsync<DCTemplate>, IDCTemplateRepository
    {
        public DCTemplateRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DCTemplate>().AnyAsync(x => x.Id == id);
        }

        public async Task<DCTemplate> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DCTemplate>()
            .Include(x => x.DCTemplateTasks.OrderBy(t => t.LineNumber))
                .ThenInclude(t => t.DcTemplateDetails)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}