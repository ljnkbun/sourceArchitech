using System.Linq.Expressions;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IArticleBaseColorRepository : IGenericRepositoryAsync<ArticleBaseColor>
    {
        Task<List<ArticleBaseColor>> GetListAsync(Expression<Func<ArticleBaseColor, bool>> predicate);
    }
}
