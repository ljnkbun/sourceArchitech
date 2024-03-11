using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IRequestArticleOutputRepository : IGenericRepositoryAsync<RequestArticleOutput>
    {
        Task<RequestArticleOutput> GetRequestArticleOutputByIdAsync(int id);
        Task<bool> IsExistAsync(int id);
        Task UpdateStatusAnalyzeArticleAsync(RequestArticleOutput article, DivisionType divisionType);
        Task UpdateStatusSubmitArticleAsync(RequestArticleOutput article, DivisionType divisionType);
        Task UpdateStatusApproveArticleAsync(RequestArticleOutput article, DivisionType divisionType);
        Task UpdateStatusRejectArticleAsync(RequestArticleOutput article, DivisionType divisionType, string rejectReason);
    }
}
