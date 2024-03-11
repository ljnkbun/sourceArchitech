using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.FPPOs
{
    public class GetFPPOQuery : IRequest<Response<FPPO>>
    {
        public int Id { get; set; }
    }
    public class GetFPPOQueryHandler : IRequestHandler<GetFPPOQuery, Response<FPPO>>
    {
        private readonly IFPPORepository _response;
        public GetFPPOQueryHandler(IFPPORepository response)
        {
            _response = response;
        }
        public async Task<Response<FPPO>> Handle(GetFPPOQuery query, CancellationToken cancellationToken)
        {
            var entity = await _response.GetFPPOByIdAsync(query.Id);
            if (entity == null) return new($"FPPO Not Found (Id:{query.Id}).");
            return new Response<FPPO>(entity);
        }
    }
}
