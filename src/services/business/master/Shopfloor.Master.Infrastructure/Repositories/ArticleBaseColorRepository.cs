using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class ArticleBaseColorRepository : GenericRepositoryAsync<ArticleBaseColor>, IArticleBaseColorRepository
    {
        public ArticleBaseColorRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<ArticleBaseColor>> GetListAsync(Expression<Func<ArticleBaseColor, bool>> predicate)
        {
            return await _dbContext.Set<ArticleBaseColor>().Where(predicate).ToListAsync();
        }
    }
}
