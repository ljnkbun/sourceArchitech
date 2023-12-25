using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class ArticleFlexFieldRepository : GenericRepositoryAsync<ArticleFlexField>, IArticleFlexFieldRepository
    {
        public ArticleFlexFieldRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<ArticleFlexField>> GetListAsync(Expression<Func<ArticleFlexField, bool>> predicate)
        {
            return await _dbContext.Set<ArticleFlexField>().Where(predicate).ToListAsync();
        }
    }
}
