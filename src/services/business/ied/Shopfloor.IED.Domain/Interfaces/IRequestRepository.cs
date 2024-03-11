using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IRequestRepository : IGenericRepositoryAsync<Request>
    {
        Task<Request> GetRequestByIdAsync(int id);
        Task<bool> ApproveRequestsAsync(List<int> ids);
        Task UpdateRequestAsync(Request request, List<RequestDivision> insertRequestDivisions, List<RequestDivision> deleteRequestDivisions);
        Task<Request> AddRequestAsync(Request entity);
        Task<int> SubmitRequestAsync(int id, string requestNo);
        Task<Request> GetRequestFullRoutingByIdAsync(int id);
    }
}
