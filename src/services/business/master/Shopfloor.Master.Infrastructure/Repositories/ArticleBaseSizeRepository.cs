using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class ArticleBaseSizeRepository : GenericRepositoryAsync<ArticleBaseSize>, IArticleBaseSizeRepository
    {
        public ArticleBaseSizeRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<ArticleBaseSize>> GetListAsync(Expression<Func<ArticleBaseSize, bool>> predicate)
        {
            return await _dbContext.Set<ArticleBaseSize>().Where(predicate).ToListAsync();
        }
    }
}
