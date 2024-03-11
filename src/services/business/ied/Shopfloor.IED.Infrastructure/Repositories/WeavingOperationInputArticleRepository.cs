using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class WeavingOperationInputArticleRepository : GenericRepositoryAsync<WeavingOperationInputArticle>, IWeavingOperationInputArticleRepository
    {
        public WeavingOperationInputArticleRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<WeavingOperationInputArticle>().AnyAsync(x => x.Id == id);
        }
    }
}