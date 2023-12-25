using System.Linq.Expressions;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IArticleFlexFieldRepository : IGenericRepositoryAsync<ArticleFlexField>
    {
        Task<List<ArticleFlexField>> GetListAsync(Expression<Func<ArticleFlexField, bool>> predicate);
    }
}
