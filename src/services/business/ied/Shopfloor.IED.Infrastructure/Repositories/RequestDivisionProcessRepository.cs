using Serilog;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class RequestDivisionProcessRepository : GenericRepositoryAsync<RequestDivisionProcess>, IRequestDivisionProcessRepository
    {
        public RequestDivisionProcessRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<RequestDivisionProcess> GetRequestDivisionProcessByIdAsync(int id)
        {
            return await _dbContext.Set<RequestDivisionProcess>()
                                    .Include(p => p.RequestArticleOutputs)
                                        .ThenInclude(o => o.RequestArticleInputs)
                                    .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
