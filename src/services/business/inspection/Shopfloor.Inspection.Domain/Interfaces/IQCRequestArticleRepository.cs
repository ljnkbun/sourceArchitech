using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Domain.Interfaces
{
    public interface IQCRequestArticleRepository : IGenericRepositoryAsync<QCRequestArticle>
    {
        Task<QCRequestArticle> GetQCRequesArticletWithInspectionByIdAsync(int id);
        Task<QCRequestArticle> GetQCRequestArticleByIdAsync(int id);
        Task<List<QCRequestArticle>> GetQCRequestArticleByArticleCodeAsync(string code);
        Task<PagedResponse<IReadOnlyList<TModel>>> GetWithDetailPagedReponseAsync<TParam, TModel>(TParam parameter, int? qcTypeId, string qcRequestNo)
        where TModel : class
        where TParam : RequestParameter;
    }
}
