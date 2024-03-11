using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class RequestDivisionRepository : GenericRepositoryAsync<RequestDivision>, IRequestDivisionRepository
    {
        public RequestDivisionRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<RequestDivision>> GetListAsync(int requestId)
        {
            return await _dbContext.Set<RequestDivision>()
                            .Where(r => r.RequestId == requestId)
                            .Include(rd => rd.RequestDivisionProcesses)
                                .ThenInclude(o => o.RequestArticleOutputs)
                                    .ThenInclude(o => o.RequestArticleInputs)
                            .ToListAsync();
        }
        public async Task<RequestDivision> GetRequestDivisionByIdAsync(int id)
        {
            return await _dbContext.Set<RequestDivision>()
                 .Include(p => p.RequestDivisionProcesses)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<RequestDivision>().AnyAsync(x => x.Id == id);
        }
    }
}
