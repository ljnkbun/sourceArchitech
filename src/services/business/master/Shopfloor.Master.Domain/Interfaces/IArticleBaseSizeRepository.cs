using System.Linq.Expressions;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IArticleBaseSizeRepository : IGenericRepositoryAsync<ArticleBaseSize>
    {
        Task<List<ArticleBaseSize>> GetListAsync(Expression<Func<ArticleBaseSize, bool>> predicate);
    }
}
