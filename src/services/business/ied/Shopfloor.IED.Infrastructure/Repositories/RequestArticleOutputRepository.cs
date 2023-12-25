using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class RequestArticleOutputRepository : GenericRepositoryAsync<RequestArticleOutput>, IRequestArticleOutputRepository
    {
        public RequestArticleOutputRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<RequestArticleOutput> GetRequestArticleOutputByIdAsync(int id)
        {
            return await _dbContext.Set<RequestArticleOutput>()
                                    .Include(p => p.RequestArticleInputs)
                                    .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
